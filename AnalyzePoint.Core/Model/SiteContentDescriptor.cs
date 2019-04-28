using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public abstract class SiteContentDescriptor : Descriptor
  {
    public SiteContentDescriptor ContainingSite { get; set; }
  }
}
