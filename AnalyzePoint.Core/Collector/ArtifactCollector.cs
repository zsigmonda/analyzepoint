using AnalyzePoint.Core.Factory;
using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  public class ArtifactCollector
  {
    private ICollectorFactory CollectorFactory;

    public ArtifactCollector(ICollectorFactory collectorFactory)
    {
      CollectorFactory = collectorFactory;
    }

    public ComponentCollector CollectorFor<T>() where T : Descriptor
    {
      return CollectorFactory.CreateCollectorFor<T>();
    }
  }
}
