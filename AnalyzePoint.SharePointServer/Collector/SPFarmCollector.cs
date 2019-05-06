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

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPFarmCollector : ITargetedComponentCollector<SPFarmCollector, FarmDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPFarmCollector));

    private SPFarm ComponentToProcess = SPFarm.Local;

    private SPSolutionCollector SubsequentSPSolutionCollector;
    private SPFeatureDefinitionCollector SubsequentSPFeatureDefinitionCollector;
    private SPServerCollector SubsequentSPServerCollector;
    private SPServiceCollector SubsequentSPServiceCollector;
    private SPServiceInstanceCollector SubsequentSPServiceInstanceCollector;

    public SPFarmCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPFarm;

      return this;
    }

    public SPFarmCollector ForComponent(SPFarm componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<FarmDescriptor> Process(object componentToProcess)
    {
      return Process(componentToProcess as SPFarm);
    }
    
    public IEnumerable<FarmDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<FarmDescriptor> Process(SPFarm farm)
    {
      try
      {
        if (farm == null)
          throw new ArgumentNullException(nameof(farm));

        Logger.Info($"Collecting objects from SharePoint farm started.");

        FarmDescriptor model = new FarmDescriptor(
          farm.Id,
          farm.Name,
          farm.DisplayName);

        model.BuildVersion = farm.BuildVersion;

        //Collect elements with subsequent collectors

        //Collect solutions within the farm
        if (SubsequentSPSolutionCollector != null)
        {
          model.Solutions.AddRange(SubsequentSPSolutionCollector.Process(farm));
        }

        //Collect feature definitions of the farm, and bind them to the solutions
        if (SubsequentSPFeatureDefinitionCollector != null)
        {
          model.FeatureDefinitions.AddRange(SubsequentSPFeatureDefinitionCollector.WithComponentDefinitions(model.Solutions).Process(farm));
        }

        //Collect server instances within the farm
        if (SubsequentSPServerCollector != null)
        {
          model.Servers.AddRange(SubsequentSPServerCollector.Process(farm));
        }

        //Collect services within the farm
        if (SubsequentSPServiceCollector != null)
        {
          model.Services.AddRange(SubsequentSPServiceCollector.WithComponentDefinitions(model.FeatureDefinitions).Process(farm));
        }

        //If we have collected services and servers, we may collect their instances
        if (SubsequentSPServerCollector != null && SubsequentSPServiceCollector != null && SubsequentSPServiceInstanceCollector != null)
        {
          model.ServiceInstances.AddRange(SubsequentSPServiceInstanceCollector.WithComponentDefinitions(model.Servers).WithComponentDefinitions(model.Services).Process(farm));
        }

        return new[] { model };
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint Farm artifacts.", ex);
        throw;
      }
      finally
      {
        Logger.Info($"Collecting objects from SharePoint farm finished.");
      }
    }

    public SPFarmCollector WithSubsequentCollector(SPSolutionCollector collector)
    {
      this.SubsequentSPSolutionCollector = collector;

      return this;
    }

    public SPFarmCollector WithSubsequentCollector(SPFeatureDefinitionCollector collector)
    {
      this.SubsequentSPFeatureDefinitionCollector = collector;

      return this;
    }

    public SPFarmCollector WithSubsequentCollector(SPServerCollector collector)
    {
      this.SubsequentSPServerCollector = collector;

      return this;
    }

    public SPFarmCollector WithSubsequentCollector(SPServiceCollector collector)
    {
      this.SubsequentSPServiceCollector = collector;

      return this;
    }

    public SPFarmCollector WithSubsequentCollector(SPServiceInstanceCollector collector)
    {
      this.SubsequentSPServiceInstanceCollector = collector;

      return this;
    }
  }
}
