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
  public class SPSolutionCollector : ComponentCollector
  {
    public override ComponentCollector ForComponent(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Collects all the farm solutions added to the SharePoint farm.
    /// </summary>
    /// <param name="componentToProcess">The SharePoint farm where to look for solutions.</param>
    /// <returns>An enumeration of farm solution descriptor objects.</returns>
    public IEnumerable<SolutionDescriptor> Process(SPFarm componentToProcess)
    {
      List<SolutionDescriptor> resultSet = new List<SolutionDescriptor>();

      foreach (SPSolution farmSolution in componentToProcess.Solutions)
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

    public override IEnumerable<Descriptor> Process()
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<Descriptor> Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }
  }
}
