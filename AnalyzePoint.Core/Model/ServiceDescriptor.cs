using AnalyzePoint.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class ServiceDescriptor : Descriptor
  {
    public string TypeName { get; set; }

    public bool IsHidden { get; set; }

    public bool IsSytemService { get; set; }

    public ServiceType ServiceType { get; set; }

    public ServiceDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      IsDeployed = true;
      ServiceType = ServiceType.Other;
    }

    public override string ToString()
    {
      return $"SharePoint Service (ID: {ID}, Type name: {TypeName})";
    }
  }
}
