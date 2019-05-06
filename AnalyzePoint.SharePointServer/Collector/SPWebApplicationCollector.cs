using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using log4net;
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
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPWebApplicationCollector));
    private SPWebService ComponentToProcess;
    private SPFeatureCollector SubsequentSPFeatureCollector;
    private SPSiteCollector SubsequentSPSiteCollector;
    private IEnumerable<FeatureDefinitionDescriptor> FeatureDefinitions;

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
      try
      {
        if (webService == null)
          throw new ArgumentNullException(nameof(webService));

        List<WebApplicationDescriptor> resultSet = new List<WebApplicationDescriptor>();

        foreach (var webApp in webService.WebApplications)
        {
          WebApplicationDescriptor model = new WebApplicationDescriptor(webApp.Id, webApp.Name, webApp.DisplayName);

          if (SubsequentSPFeatureCollector != null)
          {
            IEnumerable<FeatureDescriptor> features = SubsequentSPFeatureCollector.WithComponentDefinitions(this.FeatureDefinitions).Process(webApp);

            foreach (var f in features)
            {
              model.Features.Add(f);
            }
          }

          if (SubsequentSPSiteCollector != null)
          {
            model.SiteCollections.AddRange(SubsequentSPSiteCollector.WithComponentDefinitions(this.FeatureDefinitions).Process(webApp));
          }

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint web applications from SPWebService.", ex);
        throw;
      }
    }

    public SPWebApplicationCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      this.FeatureDefinitions = componentDefinitions;

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
