using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  public interface IDefinitionBoundComponentCollector<T, U> : IComponentCollector<T> where T : Descriptor where U : Descriptor 
  {
    IComponentCollector<T> WithComponentDefinitions(IEnumerable<U> componentDefinitions);
  }
}
