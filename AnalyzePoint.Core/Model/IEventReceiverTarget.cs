using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public interface IEventReceiverTarget
  {
    System.Collections.ObjectModel.ObservableCollection<EventReceiverDescriptor> EventReceivers { get; }
  }
}
