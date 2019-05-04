﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Factory;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint.Administration;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class CollectorFactory : ICollectorFactory
  {
    public ComponentCollector CreateCollectorFor<T>() where T : Descriptor
    {
      if (typeof(T).Name == "FarmDescriptor")
      {
        return CreateSPFarmCollector();
      }

      if (typeof(T).Name == "ListDescriptor")
      {
        return CreateSPListCollector();
      }

      if (typeof(T).Name == "SitDescriptor")
      {
        return CreateSPWebCollector();
      }

      return null;
    }

    public SPFarmCollector CreateSPFarmCollector()
    {
      return new SPFarmCollector().ForComponent(SPFarm.Local)
        .WithSubsequentCollector(CreateSPFeatureDefinitionCollector())
        .WithSubsequentCollector(CreateSPServerCollector())
        .WithSubsequentCollector(CreateSPSolutionCollector());
    }

    public SPListCollector CreateSPListCollector()
    {
      return new SPListCollector();
    }

    public SPWebCollector CreateSPWebCollector()
    {
      return new SPWebCollector();
    }

    public SPFeatureDefinitionCollector CreateSPFeatureDefinitionCollector()
    {
      return new SPFeatureDefinitionCollector();
    }

    public SPServerCollector CreateSPServerCollector()
    {
      return new SPServerCollector();
    }

    public SPSolutionCollector CreateSPSolutionCollector()
    {
      return new SPSolutionCollector();
    }
  }
}
