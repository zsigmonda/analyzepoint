using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Collector
{
  public interface ICollectorFactory
  {
    IComponentCollector<T> CreateCollectorFor<T>() where T : Descriptor;
  }
}
