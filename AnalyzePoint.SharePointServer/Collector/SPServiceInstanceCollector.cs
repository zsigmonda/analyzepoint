using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Model;
using AnalyzePoint.Core.Collector;
using Microsoft.SharePoint.Administration;
using log4net;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPServiceInstanceCollector : ITargetedComponentCollector<SPServiceInstanceCollector, ServiceInstanceDescriptor>,
    IDefinitionBoundComponentCollector<SPServiceInstanceCollector, ServiceInstanceDescriptor, ServerDescriptor>,
    IDefinitionBoundComponentCollector<SPServiceInstanceCollector, ServiceInstanceDescriptor, ServiceDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPServiceInstanceCollector));
    private SPFarm ComponentToProcess = SPFarm.Local;
    private IEnumerable<ServerDescriptor> Servers = new ServerDescriptor[0];
    private IEnumerable<ServiceDescriptor> Services = new ServiceDescriptor[0];

    public SPServiceInstanceCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPFarm;

      return this;
    }

    public SPServiceInstanceCollector ForComponent(SPFarm componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<ServiceInstanceDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<ServiceInstanceDescriptor> Process(object componentToProcess)
    {
      return Process(componentToProcess as SPFarm);
    }

    public IEnumerable<ServiceInstanceDescriptor> Process(SPFarm farm)
    {
      try
      {
        if (farm == null)
          throw new ArgumentNullException(nameof(farm));

        List<ServiceInstanceDescriptor> resultSet = new List<ServiceInstanceDescriptor>();

        foreach (var server in farm.Servers)
        {
          ServerDescriptor serverModel = Servers.Where(s => s.ID == server.Id).SingleOrDefault();

          if (serverModel != null)
          {
            foreach (var serviceInstance in server.ServiceInstances)
            {
              ServiceDescriptor serviceModel = Services.Where(s => s.ID == serviceInstance.Service.Id).SingleOrDefault();

              if (serviceModel != null)
              {
                ServiceInstanceDescriptor model = new ServiceInstanceDescriptor(serviceInstance.Id, serviceInstance.Name, serviceInstance.Instance);
                model.Server = serverModel;
                model.Service = serviceModel;

                resultSet.Add(model);
              }
            }
          }
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint service instances from SPFarm.", ex);
        throw;
      }
    }

    public SPServiceInstanceCollector WithComponentDefinitions(IEnumerable<ServerDescriptor> componentDefinitions)
    {
      if (componentDefinitions == null)
      {
        componentDefinitions = new ServerDescriptor[0];
      }

      Servers = componentDefinitions;

      return this;
    }

    public SPServiceInstanceCollector WithComponentDefinitions(IEnumerable<ServiceDescriptor> componentDefinitions)
    {
      if (componentDefinitions == null)
      {
        componentDefinitions = new ServiceDescriptor[0];
      }

      Services = componentDefinitions;

      return this;
    }
  }
}
