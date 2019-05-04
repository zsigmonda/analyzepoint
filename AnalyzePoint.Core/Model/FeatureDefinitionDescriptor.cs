using AnalyzePoint.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class FeatureDefinitionDescriptor : Descriptor
  {
    public FeatureScope Scope { get; set; }

    public SolutionDescriptor ContainingSolution { get; set; }

    public bool IsBuiltIn { get; set; }

    public int CompatibilityLevel { get; set; }

    public bool IsHidden { get; set; }

    public string Description { get; set; }

    public FeatureDefinitionDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {

    }
  }
}
