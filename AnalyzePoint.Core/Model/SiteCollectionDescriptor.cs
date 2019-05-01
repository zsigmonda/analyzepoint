using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SiteCollectionDescriptor : Descriptor, IFeatureTarget
  {
    /// <summary>
    /// This list contains all the features activated at this site collection.
    /// </summary>
    public List<FeatureDescriptor> Features { get; protected set; }

    public SiteCollectionDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      this.Features = new List<FeatureDescriptor>();
    }
  }
}
