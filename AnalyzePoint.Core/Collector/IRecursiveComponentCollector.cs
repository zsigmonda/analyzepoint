using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  public interface IRecursiveComponentCollector<T> : IComponentCollector<T> where T : Descriptor
  {
    bool IsRecursionEnabled { get; }
    int RecursionDepthLimit { get; }
  
    IRecursiveComponentCollector<T> WithoutRecursion();
    IRecursiveComponentCollector<T> WithRecursion();
    IRecursiveComponentCollector<T> WithRecursion(int depthLimit);
  }
}
