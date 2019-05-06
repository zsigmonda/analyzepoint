using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using log4net;
using Microsoft.SharePoint;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPListCollector : ITargetedComponentCollector<SPListCollector, ListDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPListCollector));

    public SPListCollector ForComponent(object componentToProcess)
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
