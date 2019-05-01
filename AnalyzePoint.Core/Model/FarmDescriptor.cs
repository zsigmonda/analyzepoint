using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class FarmDescriptor : Descriptor, IFeatureTarget
  {
    /// <summary>
    /// This list contains all the farm solutions that are installed on this farm. This list contains both deployed and retracted/not yet deployed solutions.
    /// </summary>
    public List<SolutionDescriptor> Solutions { get; protected set; }

    /// <summary>
    /// This list contains all the features activated at farm level.
    /// </summary>
    public List<FeatureDescriptor> Features { get; protected set; }

    /// <summary>
    /// This list contains all the feature definitions registeres within the farm.
    /// </summary>
    public List<FeatureDescriptor> FeatureDefinitions { get; protected set; }

    /// <summary>
    /// This list contains all the web applications hosted within the farm, including the Central Administration portal.
    /// </summary>
    public List<WebApplicationDescriptor> WebApplications { get; protected set; }

    public List<ServerDescriptor> Servers { get; protected set; }

    public List<ServiceDescriptor> Services { get; protected set; }

    public Version BuildVersion { get; set; }

    public FarmDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      this.IsDeployed = true;

      this.Solutions = new List<SolutionDescriptor>();
      this.Features = new List<FeatureDescriptor>();
      this.WebApplications = new List<WebApplicationDescriptor>();
      this.Servers = new List<ServerDescriptor>();
      this.Services = new List<ServiceDescriptor>();
    }
  }
}
