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
  public class SPFarmCollector : ComponentCollector
  {
    private SPFarm ComponentToProcess;

    private SPSolutionCollector SubsequentSPSolutionCollector;
    private SPFeatureDefinitionCollector SubsequentSPFeatureDefinitionCollector;
    private SPServerCollector SubsequentSPServerCollector;
    private SPServiceCollector SubsequentSPServiceCollector;

    public override ComponentCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPFarm;

      return this;
    }

    public override IEnumerable<Descriptor> Process(object componentToProcess)
    {
      FarmDescriptor descriptor = Process(componentToProcess as SPFarm);
      return new[] { descriptor };
    }


    public override IEnumerable<Descriptor> Process()
    {
      FarmDescriptor descriptor = Process(SPFarm.Local);
      return new[] { descriptor };
    }

    public SPFarmCollector ForComponent(SPFarm componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public FarmDescriptor Process(SPFarm farm)
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
      foreach(SPSolution solution in farm.Solutions)
      {
        model.Solutions.Add(SubsequentSPSolutionCollector.Process(solution));
      }

      //Collect feature definitions within the farm
      foreach (SPFeatureDefinition featureDefinition in farm.FeatureDefinitions)
      {
        model.FeatureDefinitions.Add(SubsequentSPFeatureDefinitionCollector.Process(featureDefinition));
      }
      
      //Collect server instances within the farm
      foreach (SPServer server in farm.Servers)
      {
        model.Servers.Add(SubsequentSPServerCollector.Process(server));
      }
      
      return model;
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
