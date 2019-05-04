using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SolutionDescriptor : Descriptor
  {
    /// <summary>
    /// This list contains all the feature definitions that are embedded into this farm solution.
    /// </summary>
    public List<FeatureDefinitionDescriptor> FeatureDefinitions { get; protected set; }

    /// <summary>
    /// This list contains all the web applications where this farm solution is deployed to.
    /// </summary>
    public List<WebApplicationDescriptor> DeployedTo { get; protected set; }

    public byte[] WspFile { get; set; }

    public SolutionDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      this.FeatureDefinitions = new List<FeatureDefinitionDescriptor>();
      this.DeployedTo = new List<WebApplicationDescriptor>();
    }
  }
}
