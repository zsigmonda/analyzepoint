using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Common;
using log4net;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPServiceCollector : IDefinitionBoundComponentCollector<SPServiceCollector, ServiceDescriptor, FeatureDefinitionDescriptor>,
    ITargetedComponentCollector<SPServiceCollector, ServiceDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPServiceCollector));
    private SPFarm ComponentToProcess;
    private SPWebApplicationCollector SubsequentSPWebApplicationCollector;
    private SPFeatureCollector SubsequentSPFeatureCollector;
    private IEnumerable<FeatureDefinitionDescriptor> FeatureDefinitions;

    public SPServiceCollector()
    {
      ComponentToProcess = SPFarm.Local;
    }

    public SPServiceCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPFarm;

      return this;
    }

    public SPServiceCollector ForComponent(SPFarm componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<ServiceDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<ServiceDescriptor> Process(object componentToProcess)
    {
      return Process(componentToProcess as SPFarm);
    }

    /// <summary>
    /// Collects all Sharepoint services running on the SharePoint farm.
    /// </summary>
    /// <param name="farm">The SharePoint farm where the services belong to.</param>
    /// <returns>An enumeration of service descriptor objects.</returns>
    public IEnumerable<ServiceDescriptor> Process(SPFarm farm)
    {
      try
      {
        if (farm == null)
          throw new ArgumentNullException(nameof(farm));

        List<ServiceDescriptor> resultSet = new List<ServiceDescriptor>();

        //These are specialized services
        Guid contentWebServiceId = SPWebService.ContentService.Id;
        Guid centralAdminWebServiceId = SPWebService.AdministrationService.Id;
        Guid timerJobServiceId = farm.TimerService.Id;

        foreach (SPService service in farm.Services)
        {
          ServiceDescriptor model;

          if (service.Id == contentWebServiceId)
          {
            model = new WebServiceDescriptor(service.Id, service.Name, service.DisplayName);
            model.ServiceType = ServiceType.ContentService;

            if (SubsequentSPWebApplicationCollector != null)
            {
              ((WebServiceDescriptor)model).WebApplications.AddRange(SubsequentSPWebApplicationCollector.WithComponentDefinitions(this.FeatureDefinitions).Process(service as SPWebService));
            }

            if (SubsequentSPFeatureCollector != null)
            {
              WebServiceDescriptor specificModel = (WebServiceDescriptor)model;

              IEnumerable<FeatureDescriptor> features = SubsequentSPFeatureCollector.WithComponentDefinitions(this.FeatureDefinitions).Process(service as SPWebService);

              foreach (var f in features)
              {
                specificModel.Features.Add(f);
              }
            }
          }
          else if (service.Id == centralAdminWebServiceId)
          {
            model = new WebServiceDescriptor(service.Id, service.Name, service.DisplayName);
            model.ServiceType = ServiceType.CentralAdministrationService;

            if (SubsequentSPWebApplicationCollector != null)
            {
              ((WebServiceDescriptor)model).WebApplications.AddRange(SubsequentSPWebApplicationCollector.WithComponentDefinitions(this.FeatureDefinitions).Process(service as SPWebService));
            }

            if (SubsequentSPFeatureCollector != null)
            {
              WebServiceDescriptor specificModel = (WebServiceDescriptor)model;

              IEnumerable<FeatureDescriptor> features = SubsequentSPFeatureCollector.WithComponentDefinitions(this.FeatureDefinitions).Process(service as SPWebService);

              foreach (var f in features)
              {
                specificModel.Features.Add(f);
              }
            }
          }
          else if (service.Id == timerJobServiceId)
          {
            model = new TimerServiceDescriptor(service.Id, service.Name, service.DisplayName);
          }
          else
          {
            model = new ServiceDescriptor(service.Id, service.Name, service.DisplayName);
            model.ServiceType = GetServiceType(service);
          }

          model.IsDeployed = true;
          model.TypeName = service.TypeName;
          model.IsHidden = service.Hidden;
          model.IsSytemService = service.SystemService;

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint services from SPFarm.", ex);
        throw;
      }
    }

    public SPServiceCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      FeatureDefinitions = componentDefinitions;

      return this;
    }

    public SPServiceCollector WithSubsequentCollector(SPWebApplicationCollector collector)
    {
      this.SubsequentSPWebApplicationCollector = collector;

      return this;
    }

    public SPServiceCollector WithSubsequentCollector(SPFeatureCollector collector)
    {
      this.SubsequentSPFeatureCollector = collector;

      return this;
    }

    /// <summary>
    /// Retrieves the type of the SharePoint Service passed as parameter.
    /// </summary>
    /// <param name="service">The SharePoint Service whose type we want to identify.</param>
    /// <returns>The type of the service based on the exact type of the object.</returns>
    private ServiceType GetServiceType(SPService service)
    {
      //All the following are SPService descendants
      if (service is SPDiagnosticsServiceBase)
      {
        return ServiceType.DiagnosticsService;
      }
      else if (service is SPIisWebService)
      {
        return ServiceType.IisWebService;
      }
      else if (service is SPIncomingEmailService)
      {
        return ServiceType.IncomingEmailService;
      }
      else if (service is SPOutboundMailService)
      {
        return ServiceType.OutboundEmailService;
      }
      else if (service is SPRequestManagementService)
      {
        return ServiceType.RequestManagementService;
      }
      else if (service is SPUsageService)
      {
        return ServiceType.UsageService;
      }
      else if (service is SPWebService)
      {
        return ServiceType.ContentService;
      }
      
      //All the following are SPWindowsService descendants
      else if (service is SPDatabaseService)
      {
        return ServiceType.DatabaseService;
      }
      else if (service is SPTimerService)
      {
        return ServiceType.TimerService;
      }
      else if (service is SPTracingService)
      {
        return ServiceType.TracingService;
      }
      else if (service is SPUserCodeService)
      {
        return ServiceType.UserCodeService;
      }
      else if (service is SPWindowsService)
      {
        return ServiceType.WindowsService;
      }
      else
      {
        return ServiceType.Other;
      }
    }
  }
}
