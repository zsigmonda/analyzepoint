using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class ServiceDescriptor : BaseDescriptor
  {
    public List<ServiceInstanceDescriptor> Instances { get; protected set; }

    public ServiceDescriptor(SPService service) : base(service)
    {
      IsDeployed = true;

      this.Instances = new List<ServiceInstanceDescriptor>();
    }
  }
}
