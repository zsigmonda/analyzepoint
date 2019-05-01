using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPFarmCollector : ComponentCollector
  {
    private SPFarm ArtifactToCollect;

    public SPFarm ComponentToProcess => throw new NotImplementedException();

    public override Descriptor Process()
    {
      FarmDescriptor model = new FarmDescriptor(
        ArtifactToCollect.Id,
        ArtifactToCollect.Name,
        ArtifactToCollect.DisplayName);

      model.BuildVersion = ArtifactToCollect.BuildVersion;

      //Collect elements with subsequent collectors

      return model;
    }

    public virtual ComponentCollector ForComponent(SPFarm farm)
    {
      ArtifactToCollect = farm;

      return this;
    }

    public Descriptor Process(SPFarm artifactToProcess)
    {
      throw new NotImplementedException();
    }

    public override Descriptor Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public override ComponentCollector ForComponent(object componentToProcess)
    {
      throw new NotImplementedException();
    }
  }
}
