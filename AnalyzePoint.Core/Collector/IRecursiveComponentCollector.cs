using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  public interface IRecursiveComponentCollector<Self, T> : IComponentCollector<T>
    where Self : IRecursiveComponentCollector<Self, T>
    where T : Descriptor
  {
    bool IsRecursionEnabled { get; }
    int RecursionDepthLimit { get; }
  
    Self WithoutRecursion();
    Self WithRecursion();
    Self WithRecursion(int depthLimit);
  }
}
