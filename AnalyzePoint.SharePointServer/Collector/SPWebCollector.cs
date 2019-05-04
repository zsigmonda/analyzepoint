﻿using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPWebCollector : ComponentCollector
  {
    public int RecursionDepthLimit { get; protected set; }
    public bool IsRecursionEnabled { get; protected set; }

    public override ComponentCollector ForComponent(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<Descriptor> Process()
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<Descriptor> Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public virtual ComponentCollector WithoutRecursion()
    {
      IsRecursionEnabled = false;

      return this;
    }

    public virtual ComponentCollector WithRecursion()
    {
      return WithRecursion(0);
    }

    public virtual ComponentCollector WithRecursion(int depthLimit)
    {
      RecursionDepthLimit = depthLimit;
      IsRecursionEnabled = true;

      return this;
    }
  }
}
