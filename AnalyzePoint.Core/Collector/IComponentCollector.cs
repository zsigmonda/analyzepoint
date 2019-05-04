using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Model;

namespace AnalyzePoint.Core.Collector
{
  public interface IComponentCollector<T> where T : Descriptor
  {
    IEnumerable<T> Process();
    IEnumerable<T> Process(object componentToProcess);
    IComponentCollector<T> ForComponent(object componentToProcess);
  }
}
