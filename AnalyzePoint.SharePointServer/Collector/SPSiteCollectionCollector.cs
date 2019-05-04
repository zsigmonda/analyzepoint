using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPSiteCollectionCollector : IComponentCollector<SiteCollectionDescriptor>
  {
    public IComponentCollector<SiteCollectionDescriptor> ForComponent(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<SiteCollectionDescriptor> Process()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<SiteCollectionDescriptor> Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }
  }
}
