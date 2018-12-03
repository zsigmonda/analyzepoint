using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class WebApplicationDescriptor : BaseDescriptor
  {
    /// <summary>
    /// This list contains all the Site Collections that belong to this web application
    /// </summary>
    public List<SiteCollectionDescriptor> SiteCollections { get; protected set; }

    /// <summary>
    /// This list contains all the features available for this web application
    /// </summary>
    public List<FeatureDescriptor> Features { get; protected set; }

    /// <summary>
    /// This list contains all the farm solutions that are deployed for this web application (including globally deployed farm solutions).
    /// </summary>
    public List<SolutionDescriptor> DeployedSolutions { get; protected set; }
    public WebApplicationDescriptor(Guid identifier) : base(identifier)
    {
      this.SiteCollections = new List<SiteCollectionDescriptor>();
      this.Features = new List<FeatureDescriptor>();
      this.DeployedSolutions = new List<SolutionDescriptor>();
    }
  }
}
