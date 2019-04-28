using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Factory
{
  public interface ICollectorFactory
  {
    ComponentCollector CreateCollectorFor<T>();
  }
}
