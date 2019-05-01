using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class ServiceInstanceDescriptor : Descriptor
  {
    public ServiceInstanceDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      IsDeployed = true;
    }
  }
}
