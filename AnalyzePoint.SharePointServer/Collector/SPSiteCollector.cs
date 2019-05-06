using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using log4net;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPSiteCollector : ITargetedComponentCollector<SPSiteCollector, SiteCollectionDescriptor>,
    IDefinitionBoundComponentCollector<SPSiteCollector, SiteCollectionDescriptor, FeatureDefinitionDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPSiteCollector));
    private SPWebApplication ComponentToProcess;
    private IEnumerable<FeatureDefinitionDescriptor> FeatureDefinitions;
    private SPFeatureCollector SubsequentSPFeatureCollector;
    private SPWebCollector SubsequentSPWebCollector;

    public SPSiteCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPWebApplication;

      return this;
    }

    public IEnumerable<SiteCollectionDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<SiteCollectionDescriptor> Process(object componentToProcess)
    {
      return Process(componentToProcess as SPWebApplication);
    }

    public IEnumerable<SiteCollectionDescriptor> Process(SPWebApplication webApplication)
    {
      try
      {
        if (webApplication == null)
          throw new ArgumentNullException(nameof(webApplication));

        List<SiteCollectionDescriptor> resultSet = new List<SiteCollectionDescriptor>();

        foreach (SPSite siteCollection in webApplication.Sites)
        {
          SiteCollectionDescriptor model = new SiteCollectionDescriptor(siteCollection.ID, siteCollection.Url, siteCollection.Url);

          if (SubsequentSPFeatureCollector != null)
          {
            IEnumerable<FeatureDescriptor> features = SubsequentSPFeatureCollector.WithComponentDefinitions(this.FeatureDefinitions).Process(siteCollection);

            foreach (var f in features)
            {
              model.Features.Add(f);
            }
          }

          if (SubsequentSPWebCollector != null)
          {
            model.RootSite = SubsequentSPWebCollector.WithComponentDefinitions(FeatureDefinitions).WithoutRecursion().Process(siteCollection).FirstOrDefault();
          }

          resultSet.Add(model);

          siteCollection.Dispose();
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint site collections from SPWebApplication.", ex);
        throw;
      }
    }

    public SPSiteCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      FeatureDefinitions = componentDefinitions;

      return this;
    }

    public SPSiteCollector WithSubsequentCollector(SPFeatureCollector collector)
    {
      this.SubsequentSPFeatureCollector = collector;

      return this;
    }

    public SPSiteCollector WithSubsequentCollector(SPWebCollector collector)
    {
      this.SubsequentSPWebCollector = collector;

      return this;
    }
  }
}
