using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class WebServiceDescriptor : ServiceDescriptor, IFeatureTarget
  {
    /// <summary>
    /// This list contains all the features activated at farm level.
    /// </summary>
    public List<FeatureDescriptor> Features { get; protected set; }

    /// <summary>
    /// This list contains all the web applications within a farm.
    /// </summary>
    public List<WebApplicationDescriptor> WebApplications { get; protected set; }

    public WebServiceDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      ;
    }
  }
}
