using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPSiteCollector : ITargetedComponentCollector<SPSiteCollector, SiteCollectionDescriptor>,
    IDefinitionBoundComponentCollector<SPSiteCollector, SiteCollectionDescriptor, FeatureDefinitionDescriptor>
  {
    private SPWebApplication ComponentToProcess;
    private IEnumerable<FeatureDefinitionDescriptor> ComponentDefinitions;
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
      if (webApplication == null)
        throw new ArgumentNullException(nameof(webApplication));

      List<SiteCollectionDescriptor> resultSet = new List<SiteCollectionDescriptor>();

      foreach(SPSite siteCollection in webApplication.Sites)
      {
        SiteCollectionDescriptor model = new SiteCollectionDescriptor(siteCollection.ID, siteCollection.Url, siteCollection.Url);

        if (SubsequentSPFeatureCollector != null)
        {
          model.Features.AddRange(SubsequentSPFeatureCollector.WithComponentDefinitions(ComponentDefinitions).Process(siteCollection));
        }

        if (SubsequentSPWebCollector != null)
        {
          model.RootSite = SubsequentSPWebCollector.WithComponentDefinitions(ComponentDefinitions).Process(siteCollection).FirstOrDefault();
        }

        resultSet.Add(model);
      }

      return resultSet;
    }

    public SPSiteCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      ComponentDefinitions = componentDefinitions;

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
