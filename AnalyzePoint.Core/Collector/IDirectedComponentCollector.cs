using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  interface IDirectedComponentCollector<T> : IComponentCollector<T> where T : Descriptor
  {
    IEnumerable<T> Process(object componentToProcess);
    IComponentCollector<T> ForComponent(object componentToProcess);
  }
}
