using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPListCollector : IComponentCollector<ListDescriptor>
  {
    public IComponentCollector<ListDescriptor> ForComponent(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ListDescriptor> Process()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ListDescriptor> Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }
  }
}
