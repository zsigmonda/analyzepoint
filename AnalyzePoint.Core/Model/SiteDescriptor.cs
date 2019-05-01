using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SiteDescriptor : SiteContentDescriptor, IFeatureTarget
  {
    public List<SiteContentDescriptor> Contents { get; protected set; }

    /// <summary>
    /// This list contains all the features activated at this site.
    /// </summary>
    public List<FeatureDescriptor> Features { get; protected set; }


    public SiteDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      Contents = new List<SiteContentDescriptor>();
    }

    public void AddContent(SiteContentDescriptor content)
    {
      Contents.Add(content);
      content.ContainingSite = this;
    }

    public void RemoveContent(SiteContentDescriptor content)
    {
      if (Contents.Remove(content))
      {
        content.ContainingSite = null;
      }
    }
  }
}
