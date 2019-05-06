using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPFeatureDefinitionCollector : ITargetedComponentCollector<SPFeatureDefinitionCollector, FeatureDefinitionDescriptor>
  {
    private SPFarm ComponentToProcess;

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

        resultSet.Add(model);
      }

      return resultSet;
    }
  }
}
