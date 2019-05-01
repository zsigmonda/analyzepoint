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
      ComponentCollector collector = ac.CollectorFor<FarmDescriptor>();
      var v = collector.WithoutRecursion().Process();

      Console.ReadLine();

      var x = SPFarm.Local.FeatureDefinitions.Select(fd => new { fd.SolutionId, fd.Scope, fd.Id, fd.Hidden, fd.Name});
      var y = SPFarm.Local.Solutions.Select(fs => new { fs.Id, fs.DisplayName });
      Console.ReadLine();
    }
  }
}
