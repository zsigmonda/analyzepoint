using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Common;

namespace AnalyzePoint.Core.Model
{
  public class TimerServiceDescriptor : ServiceDescriptor
  {
    public List<TimerJobDefinitionDescriptor> JobDefinitions { get; set; }

    public TimerServiceDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      this.JobDefinitions = new List<TimerJobDefinitionDescriptor>();
      this.ServiceType = ServiceType.TimerService;
    }
  }
}
