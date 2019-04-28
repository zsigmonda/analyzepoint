using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Factory;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class CollectorFactory : ICollectorFactory
  {
    public ComponentCollector CreateCollectorFor<T>()
    {
      if (typeof(T).Name == "SPList")
      {
        return CreateSPListCollector();
      }

      return null;
    }

    public SPListCollector CreateSPListCollector()
    {
      return new SPListCollector();
    }
  }
}
