using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SiteCollectionDescriptor : Descriptor
  {
    /// <summary>
    /// This list contains all the features available for this site collection.
    /// </summary>
    public List<FeatureDescriptor> Features { get; protected set; }

    public SiteCollectionDescriptor() : base()
    {
      this.Features = new List<FeatureDescriptor>();
    }
  }
}
