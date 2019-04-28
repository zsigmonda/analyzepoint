using AnalyzePoint.Core.Factory;
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

    public ComponentCollector ForArtifact<T>()
    {
      return CollectorFactory.CreateCollectorFor<T>();
    }
  }
}
