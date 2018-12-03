using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Common
{
  /// <summary>
  /// Defines a set of values to describe the scope of a SharePoint feature definition.
  /// </summary>
  public enum FeatureScope
  {
    Invalid,
    None,
    Web,
    Site,
    WebApplication,
    Farm
  }
}
