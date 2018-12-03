using AnalyzePoint.Core.Common;
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
    public FeatureDefinitionDescriptor(Guid identifier) : base(identifier)
    {
      ;
    }
  }
}
