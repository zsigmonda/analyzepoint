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

    public ServerDescriptor()
    {
      IsDeployed = true;

      this.ServiceInstances = new List<ServiceInstanceDescriptor>();
    }
  }
}
