﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public interface IFeatureTarget
  {
    System.Collections.ObjectModel.ObservableCollection<FeatureDescriptor> Features { get; }
  }
}
