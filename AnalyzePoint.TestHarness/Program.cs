using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using AnalyzePoint.SharePointServer.Collector;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.TestHarness
{
  class Program
  {
    static void Main(string[] args)
    {
      AnalyzePoint.SharePointServer.Collector.CollectorFactory cf = new SharePointServer.Collector.CollectorFactory();
      AnalyzePoint.Core.Collector.ArtifactCollector ac = new Core.Collector.ArtifactCollector(cf);
      IComponentCollector<FarmDescriptor> collector = ac.CollectorFor<FarmDescriptor>();
      var v = collector.Process();

      Console.ReadLine();
    }

    static void TestObservable()
    {
      System.Collections.ObjectModel.ObservableCollection<string> oc = new System.Collections.ObjectModel.ObservableCollection<string>();      
    }
  }
}
