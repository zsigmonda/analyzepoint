using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class FarmDescriptor : Descriptor
  {
    /// <summary>
    /// This list contains all the farm solutions that are installed on this farm. This list contains both deployed and retracted/not yet deployed solutions.
    /// </summary>
    public List<SolutionDescriptor> Solutions { get; protected set; }

    /// <summary>
    /// This list contains all the feature definitions registered within the farm.
    /// </summary>
    public List<FeatureDefinitionDescriptor> FeatureDefinitions { get; protected set; }

    /// <summary>
    /// This list contains all the logical server nodes that are teamed together into the farm.
    /// </summary>
    public List<ServerDescriptor> Servers { get; protected set; }

    /// <summary>
    /// This list contains all the service applications that are available in the farm.
    /// </summary>
    public List<ServiceDescriptor> Services { get; protected set; }

    /// <summary>
    /// This list contains all the service instances in the farm. A service istance is a nominated pair of a server and a service.
    /// </summary>
    public List<ServiceInstanceDescriptor> ServiceInstances { get; protected set; }

    /// <summary>
    /// The build version of the farm. In a healthy SharePoint farm, all the server nodes have the exact same version.
    /// </summary>
    public Version BuildVersion { get; set; }

    public FarmDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      this.IsDeployed = true;

      this.FeatureDefinitions = new List<FeatureDefinitionDescriptor>();
      this.Solutions = new List<SolutionDescriptor>();
      this.Servers = new List<ServerDescriptor>();
      this.Services = new List<ServiceDescriptor>();
      this.ServiceInstances = new List<ServiceInstanceDescriptor>();
    }
  }
}
