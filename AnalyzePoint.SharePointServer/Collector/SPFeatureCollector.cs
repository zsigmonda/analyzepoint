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
  public class SPFeatureCollector : IDefinitionBoundComponentCollector<SPFeatureCollector, FeatureDescriptor, FeatureDefinitionDescriptor>,
    ITargetedComponentCollector<SPFeatureCollector, FeatureDescriptor>
  {
    private object ComponentToProcess;
    private IEnumerable<FeatureDefinitionDescriptor> ComponentDefinitions;

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
        throw new NotSupportedException();
      }
    }

    public IEnumerable<FeatureDescriptor> Process(SPWebService webService)
    {
      if (webService == null)
        throw new ArgumentNullException(nameof(webService));

      List<FeatureDescriptor> resultSet = new List<FeatureDescriptor>();

      return resultSet;
    }

    public IEnumerable<FeatureDescriptor> Process(SPWebApplication webApplication)
    {
      if (webApplication == null)
        throw new ArgumentNullException(nameof(webApplication));

      List<FeatureDescriptor> resultSet = new List<FeatureDescriptor>();

      return resultSet;
    }

    public IEnumerable<FeatureDescriptor> Process(SPSite siteCollection)
    {
      if (siteCollection == null)
        throw new ArgumentNullException(nameof(siteCollection));

      List<FeatureDescriptor> resultSet = new List<FeatureDescriptor>();

      return resultSet;
    }

    public IEnumerable<FeatureDescriptor> Process(SPWeb site)
    {
      if (site == null)
        throw new ArgumentNullException(nameof(site));

      List<FeatureDescriptor> resultSet = new List<FeatureDescriptor>();

      return resultSet;
    }

    public SPFeatureCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      ComponentDefinitions = componentDefinitions;

      return this;
    }
  }
}
