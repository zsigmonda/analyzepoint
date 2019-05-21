using AnalyzePoint.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class EventReceiverDescriptor : Descriptor
  {
    public EventReceiverEventType EventType { get; set; }

    public string ReceiverAssembly { get; set; }
    public string ReceiverClass { get; set; }

    public Descriptor Host { get; set; }

    public EventReceiverDescriptor(Guid identifier, string name, string displayName) : base(identifier, name, displayName)
    {
    }
  }
}
