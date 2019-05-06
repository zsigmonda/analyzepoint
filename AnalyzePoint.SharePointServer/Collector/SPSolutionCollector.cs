using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnalyzePoint.Core.Configuration;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPSolutionCollector : ITargetedComponentCollector<SPSolutionCollector, SolutionDescriptor>
  {
    private SPFarm ComponentToProcess;

    public SPSolutionCollector()
    {
      ComponentToProcess = SPFarm.Local;
    }

    public SPSolutionCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPFarm;

      return this;
    }

    public SPSolutionCollector ForComponent(SPFarm componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<SolutionDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<SolutionDescriptor> Process(object componentToProcess)
    {
      return Process(componentToProcess as SPFarm);
    }

    /// <summary>
    /// Collects all the farm solutions added to the SharePoint farm.
    /// </summary>
    /// <param name="farm">The SharePoint farm where to look for solutions.</param>
    /// <returns>An enumeration of farm solution descriptor objects.</returns>
    public IEnumerable<SolutionDescriptor> Process(SPFarm farm)
    {
      if (farm == null)
        throw new ArgumentNullException(nameof(farm));

      List<SolutionDescriptor> resultSet = new List<SolutionDescriptor>();

      foreach (SPSolution farmSolution in farm.Solutions)
      {
        SolutionDescriptor model = new SolutionDescriptor(farmSolution.Id, farmSolution.Name, farmSolution.DisplayName);
        model.IsDeployed = farmSolution.Deployed;

        string tempFileName = Path.Combine(AnalyzePointConfiguration.Current.TemporaryFolder.Path, Path.GetRandomFileName());

        farmSolution.SolutionFile.SaveAs(tempFileName);

        model.WspFile = File.ReadAllBytes(tempFileName);

        resultSet.Add(model);
      }

      return resultSet;
    }
  }
}
