using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using log4net;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Common;
using Microsoft.SharePoint.Workflow;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPEventReceiverCollector : ITargetedComponentCollector<SPEventReceiverCollector, EventReceiverDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPEventReceiverCollector));
    private object ComponentToProcess;

    public SPEventReceiverCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<EventReceiverDescriptor> Process(object componentToProcess)
    {
      if (componentToProcess != null)
      {
        if (componentToProcess is SPSite)
        {
          return Process(componentToProcess as SPSite);
        }
        else if (componentToProcess is SPWeb)
        {
          return Process(componentToProcess as SPWeb);
        }
        else if (componentToProcess is SPList)
        {
          return Process(componentToProcess as SPList);
        }
        else if (componentToProcess is SPContentType)
        {
          return Process(componentToProcess as SPContentType);
        }
        else
        {
          throw new NotSupportedException($"Collectiong SharePoint event receivers from type {componentToProcess.GetType().AssemblyQualifiedName} is not supported.");
        }
      }
      else
      {
        throw new ArgumentNullException(nameof(componentToProcess));
      }
    }

    public IEnumerable<EventReceiverDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<EventReceiverDescriptor> Process(SPSite siteCollection)
    {
      try
      {
        if (siteCollection == null)
          throw new ArgumentNullException(nameof(siteCollection));

        List<EventReceiverDescriptor> resultSet = new List<EventReceiverDescriptor>();

        foreach (SPEventReceiverDefinition eventReceiver in siteCollection.EventReceivers)
        {
          EventReceiverDescriptor model = new EventReceiverDescriptor(eventReceiver.Id, eventReceiver.Name, eventReceiver.Name);
          model.EventType = eventReceiver.Type.ConvertByValue<SPEventReceiverType, EventReceiverEventType>();
          model.ReceiverAssembly = eventReceiver.Assembly;
          model.ReceiverClass = eventReceiver.Class;

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint event receivers from SPSite.", ex);
        throw;
      }
    }

    public IEnumerable<EventReceiverDescriptor> Process(SPWeb site)
    {
      try
      {
        if (site == null)
          throw new ArgumentNullException(nameof(site));

        List<EventReceiverDescriptor> resultSet = new List<EventReceiverDescriptor>();

        foreach (SPEventReceiverDefinition eventReceiver in site.EventReceivers)
        {
          EventReceiverDescriptor model = new EventReceiverDescriptor(eventReceiver.Id, eventReceiver.Name, eventReceiver.Name);
          model.EventType = eventReceiver.Type.ConvertByValue<SPEventReceiverType, EventReceiverEventType>();
          model.ReceiverAssembly = eventReceiver.Assembly;
          model.ReceiverClass = eventReceiver.Class;

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint event receivers from SPWeb.", ex);
        throw;
      }
    }

    public IEnumerable<EventReceiverDescriptor> Process(SPList list)
    {
      try
      {
        if (list == null)
          throw new ArgumentNullException(nameof(list));

        List<EventReceiverDescriptor> resultSet = new List<EventReceiverDescriptor>();

        foreach (SPEventReceiverDefinition eventReceiver in list.EventReceivers)
        {
          EventReceiverDescriptor model = new EventReceiverDescriptor(eventReceiver.Id, eventReceiver.Name, eventReceiver.Name);
          model.EventType = eventReceiver.Type.ConvertByValue<SPEventReceiverType, EventReceiverEventType>();
          model.ReceiverAssembly = eventReceiver.Assembly;
          model.ReceiverClass = eventReceiver.Class;

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint event receivers from SPList.", ex);
        throw;
      }
    }

    public IEnumerable<EventReceiverDescriptor> Process(SPContentType contentType)
    {
      try
      {
        if (contentType == null)
          throw new ArgumentNullException(nameof(contentType));

        List<EventReceiverDescriptor> resultSet = new List<EventReceiverDescriptor>();

        foreach (SPEventReceiverDefinition eventReceiver in contentType.EventReceivers)
        {
          EventReceiverDescriptor model = new EventReceiverDescriptor(eventReceiver.Id, eventReceiver.Name, eventReceiver.Name);
          model.EventType = eventReceiver.Type.ConvertByValue<SPEventReceiverType, EventReceiverEventType>();
          model.ReceiverAssembly = eventReceiver.Assembly;
          model.ReceiverClass = eventReceiver.Class;

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint event receivers from SPContentType.", ex);
        throw;
      }
    }
  }
}
