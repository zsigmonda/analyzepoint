using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SiteDescriptor : SiteContentDescriptor
  {
    public List<SiteContentDescriptor> Contents { get; protected set; }

    public SiteDescriptor() : base()
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
