using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPServiceCollector : IComponentCollector<ServiceDescriptor>
  {
    private SPFarm ComponentToProcess;

    public SPServiceCollector()
    {
      ComponentToProcess = SPFarm.Local;
    }

    public IComponentCollector<ServiceDescriptor> ForComponent(object componentToProcess)
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
    /// Collects all the Services joined to the SharePoint farm.
    /// </summary>
    /// <param name="farm">The SharePoint farm where the Services belong to.</param>
    /// <returns>An enumeration of Service descriptor objects.</returns>
    public IEnumerable<ServiceDescriptor> Process(SPFarm farm)
    {
      if (farm == null)
        throw new ArgumentNullException(nameof(farm));

      List<ServiceDescriptor> resultSet = new List<ServiceDescriptor>();

      foreach (SPService service in farm.Services)
      {
        ServiceDescriptor model = new ServiceDescriptor(service.Id, service.Name, service.DisplayName);
        model.IsDeployed = true;
        model.TypeName = service.TypeName;
        
        resultSet.Add(model);
      }

      return resultSet;
    }
  }
}
