using AnalyzePoint.Core.Common;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class FeatureDefinitionDescriptor : BaseDescriptor
  {
    public FeatureScope Scope { get; set; }

    public SolutionDescriptor ContainingSolution { get; set; }

    public bool IsBuiltIn { get; set; }

    public FeatureDefinitionDescriptor(SPFeatureDefinition featureDefinition) : base(featureDefinition)
    {
      ;
    }
  }
}
