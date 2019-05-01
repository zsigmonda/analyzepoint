using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class ServiceDescriptor : Descriptor
  {
    public List<ServiceInstanceDescriptor> Instances { get; protected set; }

    public ServiceDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      IsDeployed = true;

      this.Instances = new List<ServiceInstanceDescriptor>();
    }
  }
}
