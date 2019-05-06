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
  public class SPServerCollector : ITargetedComponentCollector<SPServerCollector, ServerDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPServerCollector));
    private SPFarm ComponentToProcess;

    public SPServerCollector()
    {
      ComponentToProcess = SPFarm.Local;
    }

    public SPServerCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPFarm;

      return this;
    }

    public SPServerCollector ForComponent(SPFarm componentToProcess)
    {
      ComponentToProcess = componentToProcess;

      return this;
    }

    public IEnumerable<ServerDescriptor> Process()
    {
      return Process(ComponentToProcess);
    }

    public IEnumerable<ServerDescriptor> Process(object componentToProcess)
    {
      return Process(componentToProcess as SPFarm);
    }

    /// <summary>
    /// Collects all the servers joined to the SharePoint farm.
    /// </summary>
    /// <param name="farm">The SharePoint farm where the servers belong to.</param>
    /// <returns>An enumeration of server descriptor objects.</returns>
    public IEnumerable<ServerDescriptor> Process(SPFarm farm)
    {
      try
      {
        if (farm == null)
          throw new ArgumentNullException(nameof(farm));

        List<ServerDescriptor> resultSet = new List<ServerDescriptor>();

        foreach (SPServer server in farm.Servers)
        {
          ServerDescriptor model = new ServerDescriptor(server.Id, server.Name, server.DisplayName);
          model.IsDeployed = true;
          model.Role = EnumExtensions.ConvertByValue<SPServerRole, ServerRole>(server.Role);
          model.Address = server.Address;

          resultSet.Add(model);
        }

        return resultSet;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint servers from SPFarm.", ex);
        throw;
      }
    }
  }
}
