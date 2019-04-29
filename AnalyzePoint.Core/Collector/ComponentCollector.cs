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
    private int RecursionDepthLimit;
    private bool IsRecursionEnabled;
    private readonly List<ComponentCollector> SuccessiveCollectors;

    public abstract IEnumerable<Descriptor> CollectAll();

    public ComponentCollector()
    {
      SuccessiveCollectors = new List<ComponentCollector>();
    }

    public virtual ComponentCollector WithSuccessiveCollector(ComponentCollector successiveCollector)
    {
      SuccessiveCollectors.Add(successiveCollector);

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
