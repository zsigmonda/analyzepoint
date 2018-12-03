using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  /// <summary>
  /// This is a base class for describing all SharePoint components.
  /// </summary>
  public abstract class BaseDescriptor
  {
    public DateTime LastUpdated { get; set; }
    public Guid Identifier { get; protected set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }

    protected BaseDescriptor(Guid identifier)
    {
      this.Identifier = identifier;
    }
  }
}
