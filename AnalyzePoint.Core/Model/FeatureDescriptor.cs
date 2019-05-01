using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Common;

namespace AnalyzePoint.Core.Model
{
  public class FeatureDescriptor : Descriptor
  {
    public FeatureDefinitionDescriptor Definition { get; protected set; }

    public FeatureDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {

    }
  }
}
