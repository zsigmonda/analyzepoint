using AnalyzePoint.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class ServerDescriptor : Descriptor
  {
    public List<ServiceInstanceDescriptor> ServiceInstances { get; protected set; }

    public string Address { get; set; }

    public ServerRole Role { get; set; }

    public ServerDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      IsDeployed = true;

      this.ServiceInstances = new List<ServiceInstanceDescriptor>();
    }
  }
}
