using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  public interface ITargetedComponentCollector<Self, T> : IComponentCollector<T>
    where Self : ITargetedComponentCollector<Self, T>
    where T : Descriptor
  {
    Self ForComponent(object componentToProcess);
  }
}
