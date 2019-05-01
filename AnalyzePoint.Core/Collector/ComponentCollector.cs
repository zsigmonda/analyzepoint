using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Model;

namespace AnalyzePoint.Core.Collector
{
  public abstract class ComponentCollector
  {
    public int RecursionDepthLimit { get; protected set; }
    public bool IsRecursionEnabled { get; protected set; }
    protected List<ComponentCollector> SubsequentCollectors;

    public abstract Descriptor Process();
    public abstract Descriptor Process(object componentToProcess);
    public abstract ComponentCollector ForComponent(object componentToProcess);

    public ComponentCollector()
    {
      SubsequentCollectors = new List<ComponentCollector>();
    }

    public virtual ComponentCollector WithSubsequentCollector(ComponentCollector subsequentCollector)
    {
      SubsequentCollectors.Add(subsequentCollector);

      return this;
    }

    public virtual ComponentCollector WithoutRecursion()
    {
      IsRecursionEnabled = false;

      return this;
    }

    public virtual ComponentCollector WithRecursion()
    {
      return WithRecursion(0);
    }

    public virtual ComponentCollector WithRecursion(int depthLimit)
    {
      RecursionDepthLimit = depthLimit;
      IsRecursionEnabled = true;

      return this;
    }
  }
}
