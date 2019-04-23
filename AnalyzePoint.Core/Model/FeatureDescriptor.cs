using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Common;
using Microsoft.SharePoint;

namespace AnalyzePoint.Core.Model
{
  public class FeatureDescriptor : BaseDescriptor
  {
    public FeatureDefinitionDescriptor Definition { get; protected set; }

    public bool Activated { get; set; }

    public FeatureDescriptor(SPFeature feature)
    {
      ;
    }
  }
}
