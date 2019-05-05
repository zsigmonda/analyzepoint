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
  public class SPSiteCollector : IComponentCollector<SiteCollectionDescriptor>
  {
    private SPWebApplication ComponentToProcess;

    public IComponentCollector<SiteCollectionDescriptor> ForComponent(object componentToProcess)
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

        resultSet.Add(model);
      }

      return resultSet;
    }
  }
}
