using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Common
{
  /// <summary>
  /// Defines a set of values to describe the scope of a SharePoint feature definition.
  /// </summary>
  public enum FeatureScope
  {
    Invalid,
    None,
    Web,
    Site,
    WebApplication,
    Farm
  }

  /// <summary>
  /// Specifies the role of the server with respect to the Windows SharePoint Services deployment.
  /// </summary>  
  public enum ServerRole
  {
    /// <summary>
    /// Specifies that the server does not have a registered role in the configuration database.
    /// </summary>
    Invalid = 0,

    /// <summary>
    /// Specifies that the server is a front-end Web server within the Windows SharePoint Services deployment.
    /// </summary>    
    WebFrontEnd = 1,

    /// <summary>
    /// Specifies that the server runs a Web application.
    /// </summary>     
    Application = 2,

    /// <summary>
    /// Specifies that the server is the only server in the Windows SharePoint Services deployment.
    /// </summary>
    SingleServer = 3,
    SingleServerFarm = 4,
    DistributedCache = 5,
    Search = 6,
    Custom = 8,
    ApplicationWithSearch = 9,
    WebFrontEndWithDistributedCache = 10
  }
}
