using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class TimerJobDefinitionDescriptor : Descriptor
  {
    public TimerJobDefinitionDescriptor(Guid identifier, string name, string displayName) : base(identifier, name, displayName)
    {
    }
  }
}
