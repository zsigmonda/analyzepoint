﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class WebServiceDescriptor : ServiceDescriptor
  {
    public WebServiceDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      ;
    }
  }
}
