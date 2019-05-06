using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  public interface IDefinitionBoundComponentCollector<Self, T, TDefinition> : IComponentCollector<T>
    where Self : IDefinitionBoundComponentCollector<Self, T, TDefinition>
    where T : Descriptor
    where TDefinition : Descriptor 
  {
    Self WithComponentDefinitions(IEnumerable<TDefinition> componentDefinitions);
  }
}
