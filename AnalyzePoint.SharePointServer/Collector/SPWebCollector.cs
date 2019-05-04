using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPWebCollector : IRecursiveComponentCollector<SiteDescriptor>
  {
    public int RecursionDepthLimit { get; protected set; }
    public bool IsRecursionEnabled { get; protected set; }

    public IComponentCollector<SiteDescriptor> ForComponent(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<SiteDescriptor> Process()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<SiteDescriptor> Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public IRecursiveComponentCollector<SiteDescriptor> WithoutRecursion()
    {
      IsRecursionEnabled = false;

      return this;
    }

    public IRecursiveComponentCollector<SiteDescriptor> WithRecursion()
    {
      return WithRecursion(0);
    }

    public IRecursiveComponentCollector<SiteDescriptor> WithRecursion(int depthLimit)
    {
      RecursionDepthLimit = depthLimit;
      IsRecursionEnabled = true;

      return this;
    }
  }
}
