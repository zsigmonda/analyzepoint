using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  public abstract class BaseComponentCollector
  {
    /// <summary>
    /// This field contains all the Collectors that should be run after running this collector
    /// </summary>
    protected List<BaseComponentCollector> EmbeddedComponentCollectors;

    public BaseComponentCollector()
    {
      EmbeddedComponentCollectors = new List<BaseComponentCollector>();
    }

    public IEnumerable<BaseDescriptor> Collect(BaseDescriptor rootItem)
    {
      IEnumerable<BaseDescriptor> baseDescriptors = Run();
      foreach(BaseComponentCollector componentCollector in EmbeddedComponentCollectors)
      {
        componentCollector.Run();
      }
      return baseDescriptors;
    }

    /// <summary>
    /// This is the method where actual collection happens.
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<BaseDescriptor> Run();

    public void Add(BaseComponentCollector collector)
    {
      EmbeddedComponentCollectors.Add(collector);
    }

    public void Remove(BaseComponentCollector collector)
    {
      EmbeddedComponentCollectors.Remove(collector);
    }

    public BaseComponentCollector this[int index]
    {
      get
      {
        return EmbeddedComponentCollectors[index];
      }
      set
      {
        EmbeddedComponentCollectors[index] = value;
      }
    }
  }
}
