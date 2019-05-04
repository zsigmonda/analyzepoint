using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Configuration
{
  public class FolderConfiguration : ConfigurationElement
  {
    [ConfigurationProperty("path", IsRequired = true)]
    public string Path
    {
      get
      {
        return (string)this["path"];
      }
      set
      {
        this["path"] = value;
      }
    }
  }
}
