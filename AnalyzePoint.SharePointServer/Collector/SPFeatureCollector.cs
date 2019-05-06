using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using log4net;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPFeatureCollector : IDefinitionBoundComponentCollector<SPFeatureCollector, FeatureDescriptor, FeatureDefinitionDescriptor>,
    ITargetedComponentCollector<SPFeatureCollector, FeatureDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPFeatureCollector));
    private object ComponentToProcess;
    private IEnumerable<FeatureDefinitionDescriptor> FeatureDefinitions = new FeatureDefinitionDescriptor[0];

    public SPFeatureCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<FeatureDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<FeatureDescriptor> Process(object componentToProcess)
    {
      if (componentToProcess != null)
      {
        if (componentToProcess is SPWebService)
        {
          return Process(componentToProcess as SPWebService);
        }
        else if (componentToProcess is SPWebApplication)
        {
          return Process(componentToProcess as SPWebApplication);
        }
        else if (componentToProcess is SPSite)
        {
          return Process(componentToProcess as SPSite);
        }
        else if (componentToProcess is SPWeb)
        {
          return Process(componentToProcess as SPWeb);
        }
        else
        {
          throw new NotSupportedException($"Collectiong SharePoint features from type {componentToProcess.GetType().AssemblyQualifiedName} is not supported.");
        }
      }
      else
      {
        throw new ArgumentNullException(nameof(componentToProcess));
      }
    }

    public IEnumerable<FeatureDescriptor> Process(SPWebService webService)
    {
      try
      {
        if (webService == null)
          throw new ArgumentNullException(nameof(webService));

        List<FeatureDescriptor> resultSet = new List<FeatureDescriptor>();

        foreach (SPFeature feature in webService.Features)
        {
          FeatureDefinitionDescriptor definitionModel = FeatureDefinitions.Where(fd => fd.ID == feature.DefinitionId && fd.CompatibilityLevel == feature.Definition.CompatibilityLevel).SingleOrDefault();

          FeatureDescriptor model = new FeatureDescriptor(definitionModel);
          model.IsDeployed = feature.FeatureDefinitionScope != SPFeatureDefinitionScope.None;
          model.Version = feature.Version;

          definitionModel.Instances.Add(model);

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint features from SPWebService.", ex);
        throw;
      }
    }

    public IEnumerable<FeatureDescriptor> Process(SPWebApplication webApplication)
    {
      try
      {
        if (webApplication == null)
          throw new ArgumentNullException(nameof(webApplication));

        List<FeatureDescriptor> resultSet = new List<FeatureDescriptor>();

        foreach (SPFeature feature in webApplication.Features)
        {
          FeatureDefinitionDescriptor definitionModel = FeatureDefinitions.Where(fd => fd.ID == feature.DefinitionId && fd.CompatibilityLevel == feature.Definition.CompatibilityLevel).SingleOrDefault();

          FeatureDescriptor model = new FeatureDescriptor(definitionModel);
          model.IsDeployed = feature.FeatureDefinitionScope != SPFeatureDefinitionScope.None;
          model.Version = feature.Version;

          definitionModel.Instances.Add(model);

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint features from SPWebApplication.", ex);
        throw;
      }
    }

    public IEnumerable<FeatureDescriptor> Process(SPSite siteCollection)
    {
      try
      {
        if (siteCollection == null)
          throw new ArgumentNullException(nameof(siteCollection));

        List<FeatureDescriptor> resultSet = new List<FeatureDescriptor>();

        foreach (SPFeature feature in siteCollection.Features)
        {
          FeatureDefinitionDescriptor definitionModel = FeatureDefinitions.Where(fd => fd.ID == feature.DefinitionId && fd.CompatibilityLevel == feature.Definition.CompatibilityLevel).SingleOrDefault();

          FeatureDescriptor model = new FeatureDescriptor(definitionModel);
          model.IsDeployed = feature.FeatureDefinitionScope != SPFeatureDefinitionScope.None;
          model.Version = feature.Version;

          definitionModel.Instances.Add(model);

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint features from SPSite.", ex);
        throw;
      }
    }

    public IEnumerable<FeatureDescriptor> Process(SPWeb site)
    {
      try
      {
        if (site == null)
          throw new ArgumentNullException(nameof(site));

        List<FeatureDescriptor> resultSet = new List<FeatureDescriptor>();

        foreach (SPFeature feature in site.Features)
        {
          FeatureDefinitionDescriptor definitionModel = FeatureDefinitions.Where(fd => fd.ID == feature.DefinitionId && fd.CompatibilityLevel == feature.Definition.CompatibilityLevel).SingleOrDefault();

          FeatureDescriptor model = new FeatureDescriptor(definitionModel);
          model.IsDeployed = feature.FeatureDefinitionScope != SPFeatureDefinitionScope.None;
          model.Version = feature.Version;

          definitionModel.Instances.Add(model);

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint features from SPWeb.", ex);
        throw;
      }
    }

    public SPFeatureCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      if (componentDefinitions == null)
      {
        FeatureDefinitions = new FeatureDefinitionDescriptor[0];
      }
      else
      {
        FeatureDefinitions = componentDefinitions;
      }

      return this;
    }
  }
}
