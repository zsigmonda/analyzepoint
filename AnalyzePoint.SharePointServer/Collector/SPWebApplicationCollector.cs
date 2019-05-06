using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPWebApplicationCollector : IDefinitionBoundComponentCollector<SPWebApplicationCollector, WebApplicationDescriptor, FeatureDefinitionDescriptor>,
    ITargetedComponentCollector<SPWebApplicationCollector, WebApplicationDescriptor>
  {
    private SPWebService ComponentToProcess;
    private SPFeatureCollector SubsequentSPFeatureCollector;
    private SPSiteCollector SubsequentSPSiteCollector;
    private IEnumerable<FeatureDefinitionDescriptor> ComponentDefinitions;

    public SPWebApplicationCollector()
    {
      ComponentToProcess = SPWebService.ContentService;
    }

    public SPWebApplicationCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPWebService;

      return this;
    }

    public SPWebApplicationCollector ForComponent(SPWebService componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<WebApplicationDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<WebApplicationDescriptor> Process(object componentToProcess)
    {
      return Process(componentToProcess as SPWebService);
    }

    public IEnumerable<WebApplicationDescriptor> Process(SPWebService webService)
    {
      if (webService == null)
        throw new ArgumentNullException(nameof(webService));

      List<WebApplicationDescriptor> resultSet = new List<WebApplicationDescriptor>();

      foreach(var webApp in webService.WebApplications)
      {
        WebApplicationDescriptor model = new WebApplicationDescriptor(webApp.Id, webApp.Name, webApp.DisplayName);

        if (SubsequentSPFeatureCollector != null)
        {
          model.Features.AddRange(SubsequentSPFeatureCollector.WithComponentDefinitions(this.ComponentDefinitions).Process(webApp));
        }

        if (SubsequentSPSiteCollector != null)
        {
          model.SiteCollections.AddRange(SubsequentSPSiteCollector.WithComponentDefinitions(this.ComponentDefinitions).Process(webApp));
        }

        resultSet.Add(model);
      }

      return resultSet;
    }

    public SPWebApplicationCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      this.ComponentDefinitions = componentDefinitions;

      return this;
    }

    public SPWebApplicationCollector WithSubsequentCollector(SPFeatureCollector collector)
    {
      this.SubsequentSPFeatureCollector = collector;

      return this;
    }

    public SPWebApplicationCollector WithSubsequentCollector(SPSiteCollector collector)
    {
      this.SubsequentSPSiteCollector = collector;

      return this;
    }
  }
}
