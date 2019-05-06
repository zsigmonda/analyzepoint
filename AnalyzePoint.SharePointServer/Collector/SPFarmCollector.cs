using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
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
    private SPFarm ComponentToProcess;

    private SPSolutionCollector SubsequentSPSolutionCollector;
    private SPFeatureDefinitionCollector SubsequentSPFeatureDefinitionCollector;
    private SPServerCollector SubsequentSPServerCollector;
    private SPServiceCollector SubsequentSPServiceCollector;

    public SPFarmCollector()
    {
      ComponentToProcess = SPFarm.Local;
    }

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
      if (farm == null)
        throw new ArgumentNullException(nameof(farm));

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

      //Collect feature definitions of the farm
      if (SubsequentSPFeatureDefinitionCollector != null)
      {
        model.FeatureDefinitions.AddRange(SubsequentSPFeatureDefinitionCollector.Process(farm));
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
      if (SubsequentSPServerCollector != null && SubsequentSPServiceCollector != null)
      {
        ;
      }



      return new[] { model };
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
  }
}
