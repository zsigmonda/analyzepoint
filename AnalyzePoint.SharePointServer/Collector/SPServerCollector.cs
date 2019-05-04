using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPServerCollector : ComponentCollector
  {
    public override ComponentCollector ForComponent(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public override Descriptor Process()
    {
      throw new NotImplementedException();
    }

    public override Descriptor Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public ServerDescriptor Process(SPServer componentToProcess)
    {
      ServerDescriptor model = new ServerDescriptor(componentToProcess.Id, componentToProcess.TypeName, componentToProcess.DisplayName);

      return model;
    }
  }
}
