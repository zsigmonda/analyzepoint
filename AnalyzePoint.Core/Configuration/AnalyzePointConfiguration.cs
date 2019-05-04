using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Configuration
{
  public class AnalyzePointConfiguration : ConfigurationSection
  {
    public static readonly AnalyzePointConfiguration Current =
        (AnalyzePointConfiguration)ConfigurationManager.GetSection("AnalyzePointConfiguration");

    [ConfigurationProperty("temporaryFolder", IsRequired = false)]
    public FolderConfiguration TemporaryFolder
    {
      get { return (FolderConfiguration)this["temporaryFolder"]; }
      set { this["temporaryFolder"] = value; }
    }

    [ConfigurationProperty("workingFolder", IsRequired = false)]
    public FolderConfiguration WorkingFolder
    {
      get { return (FolderConfiguration)this["workingFolder"]; }
      set { this["workingFolder"] = value; }
    }
  }
}
