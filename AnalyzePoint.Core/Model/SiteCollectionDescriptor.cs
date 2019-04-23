using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SiteCollectionDescriptor : BaseDescriptor
  {
    /// <summary>
    /// This list contains all the features available for this site collection.
    /// </summary>
    public List<FeatureDescriptor> Features { get; protected set; }

    public SiteCollectionDescriptor(SPSite siteCollection) : base()
    {
      Identifier = siteCollection.ID;
      DisplayName = siteCollection.Url;
      Name = siteCollection.Url;

      this.Features = new List<FeatureDescriptor>();
    }
  }
}
