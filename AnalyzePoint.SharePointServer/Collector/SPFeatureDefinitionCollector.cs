using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Common;
using log4net;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPFeatureDefinitionCollector : ITargetedComponentCollector<SPFeatureDefinitionCollector, FeatureDefinitionDescriptor>,
    IDefinitionBoundComponentCollector<SPFeatureDefinitionCollector, FeatureDefinitionDescriptor, SolutionDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPFeatureDefinitionCollector));
    private SPFarm ComponentToProcess;
    private IEnumerable<SolutionDescriptor> Solutions;

    public SPFeatureDefinitionCollector()
    {
      ComponentToProcess = SPFarm.Local;
    }

    public SPFeatureDefinitionCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPFarm;

      return this;
    }

    public SPFeatureDefinitionCollector ForComponent(SPFarm componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<FeatureDefinitionDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<FeatureDefinitionDescriptor> Process(object componentToProcess)
    {
      return Process(componentToProcess as SPFarm);
    }

    public IEnumerable<FeatureDefinitionDescriptor> Process(SPFarm farm)
    {
      try
      {
        if (farm == null)
          throw new ArgumentNullException(nameof(farm));

        List<FeatureDefinitionDescriptor> resultSet = new List<FeatureDefinitionDescriptor>();

        foreach (SPFeatureDefinition featureDefinition in farm.FeatureDefinitions)
        {
          FeatureDefinitionDescriptor model = new FeatureDefinitionDescriptor(featureDefinition.Id, featureDefinition.Name, String.Empty);

          model.DisplayName = featureDefinition.GetTitle(System.Threading.Thread.CurrentThread.CurrentCulture);
          model.CompatibilityLevel = featureDefinition.CompatibilityLevel;
          model.IsHidden = featureDefinition.Hidden;
          model.Description = featureDefinition.GetDescription(System.Threading.Thread.CurrentThread.CurrentCulture);
          model.Version = featureDefinition.Version;
          model.Scope = featureDefinition.Scope.ConvertByValue<SPFeatureScope, FeatureScope>();

          if (Solutions != null)
          {
            model.ContainingSolution = Solutions.Where(s => s.ID == featureDefinition.SolutionId).SingleOrDefault();
            if (model.ContainingSolution != null)
            {
              model.ContainingSolution.FeatureDefinitions.Add(model);
            }
          }

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint feature definitions from SPFarm.", ex);
        throw;
      }
    }

    public SPFeatureDefinitionCollector WithComponentDefinitions(IEnumerable<SolutionDescriptor> componentDefinitions)
    {
      Solutions = componentDefinitions;

      return this;
    }
  }
}
