using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Factory;
using AnalyzePoint.Core.Model;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class CollectorFactory : ICollectorFactory
  {
    public ComponentCollector CreateCollectorFor<T>() where T : Descriptor, new()
    {
      if (typeof(T).Name == "ListDescriptor")
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
