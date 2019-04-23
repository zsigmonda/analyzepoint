using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Administration;

namespace AnalyzePoint.Core.Model
{
  public class WebServiceDescriptor : ServiceDescriptor
  {
    public WebServiceDescriptor(SPWebService webService) : base(webService)
    {
      ;
    }
  }
}
