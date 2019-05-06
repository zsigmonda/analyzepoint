using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Factory;
using AnalyzePoint.Core.Model;
using log4net;
using Microsoft.SharePoint.Administration;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class CollectorFactory : ICollectorFactory
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(CollectorFactory));

    public IComponentCollector<T> CreateCollectorFor<T>() where T : Descriptor
    {
      try
      {
        Logger.Debug($"Creating component collector for type {typeof(T).AssemblyQualifiedName}");

        if (typeof(T).IsEquivalentTo(typeof(FarmDescriptor)))
        {
          return CreateSPFarmCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(ServerDescriptor)))
        {
          return CreateSPServerCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(ServiceDescriptor)))
        {
          return CreateSPServiceCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(ServiceInstanceDescriptor)))
        {
          return CreateSPServiceInstanceCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(FeatureDefinitionDescriptor)))
        {
          return CreateSPFeatureDefinitionCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(ListDescriptor)))
        {
          return CreateSPListCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(SiteDescriptor)))
        {
          return CreateSPWebCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(FeatureDescriptor)))
        {
          return CreateSPFeatureCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(WebApplicationDescriptor)))
        {
          return CreateSPWebApplicationCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(SolutionDescriptor)))
        {
          return CreateSPSolutionCollector() as IComponentCollector<T>;
        }

        if (typeof(T).IsEquivalentTo(typeof(SiteCollectionDescriptor)))
        {
          return CreateSPSiteCollector() as IComponentCollector<T>;
        }

        throw new NotSupportedException($"Creating component collector for type {typeof(T).AssemblyQualifiedName} is not supported.");
      }
      catch (Exception ex)
      {
        Logger.Error(ex.Message, ex);
        throw;
      }
    }

    public SPFarmCollector CreateSPFarmCollector()
    {
      return new SPFarmCollector().ForComponent(SPFarm.Local)
        .WithSubsequentCollector(CreateSPFeatureDefinitionCollector())
        .WithSubsequentCollector(CreateSPServerCollector())
        .WithSubsequentCollector(CreateSPSolutionCollector())
        .WithSubsequentCollector(CreateSPServiceInstanceCollector())
        .WithSubsequentCollector(
          CreateSPServiceCollector()
          .WithSubsequentCollector(CreateSPFeatureCollector())
          .WithSubsequentCollector(
            CreateSPWebApplicationCollector()
            .WithSubsequentCollector(CreateSPFeatureCollector())
            .WithSubsequentCollector(CreateSPSiteCollector()
              .WithSubsequentCollector(CreateSPFeatureCollector())
              .WithSubsequentCollector(CreateSPWebCollector()
                .WithSubsequentCollector(CreateSPFeatureCollector())
                )
              )
            )
        );
    }

    public SPListCollector CreateSPListCollector()
    {
      return new SPListCollector();
    }

    public SPWebCollector CreateSPWebCollector()
    {
      return new SPWebCollector();
    }

    public SPFeatureDefinitionCollector CreateSPFeatureDefinitionCollector()
    {
      return new SPFeatureDefinitionCollector();
    }

    public SPServerCollector CreateSPServerCollector()
    {
      return new SPServerCollector();
    }

    public SPSolutionCollector CreateSPSolutionCollector()
    {
      return new SPSolutionCollector();
    }

    public SPServiceCollector CreateSPServiceCollector()
    {
      return new SPServiceCollector();
    }

    public SPServiceInstanceCollector CreateSPServiceInstanceCollector()
    {
      return new SPServiceInstanceCollector();
    }

    public SPFeatureCollector CreateSPFeatureCollector()
    {
      return new SPFeatureCollector();
    }

    public SPWebApplicationCollector CreateSPWebApplicationCollector()
    {
      return new SPWebApplicationCollector();
    }

    public SPSiteCollector CreateSPSiteCollector()
    {
      return new SPSiteCollector();
    }
  }
}
