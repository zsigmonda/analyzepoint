﻿using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using AnalyzePoint.SharePointServer.Collector;
using log4net;
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
    private static readonly ILog Logger = LogManager.GetLogger(typeof(CollectorFactory));

    static void Main(string[] args)
    {
      Logger.Info("TestHarness started.");

      AnalyzePoint.SharePointServer.Collector.CollectorFactory cf = new SharePointServer.Collector.CollectorFactory();
      AnalyzePoint.Core.Collector.ArtifactCollector ac = new Core.Collector.ArtifactCollector(cf);
      IComponentCollector<FarmDescriptor> collector = ac.CollectorFor<FarmDescriptor>();
      var v = collector.Process();

      var v2 = v.First().FeatureDefinitions.Where(f => f.ContainingSolution != null).ToList();

      Logger.Info("TestHarness finished executing.");

      Console.ReadLine();

      Logger.Info("TestHarness exited.");
    }
  }
}
