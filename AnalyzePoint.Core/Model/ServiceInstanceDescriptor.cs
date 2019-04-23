using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class ServiceInstanceDescriptor : BaseDescriptor
  {

    public ServiceInstanceDescriptor(SPServiceInstance serviceInstance) : base(serviceInstance)
    {
      IsDeployed = true;
    }
  }
}
