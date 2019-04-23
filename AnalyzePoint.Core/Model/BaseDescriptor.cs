using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
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
    public virtual string Name { get; set; }
    public virtual string DisplayName { get; set; }
    public virtual bool IsDeployed { get; set; }

    public BaseDescriptor(SPPersistedObject spObject)
    {
      Identifier = spObject.Id;
      Name = spObject.Name;
      DisplayName = spObject.DisplayName;
    }

    public BaseDescriptor()
    {

    }
  }
}
