﻿using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPServiceCollector : ComponentCollector
  {
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
  }
}
