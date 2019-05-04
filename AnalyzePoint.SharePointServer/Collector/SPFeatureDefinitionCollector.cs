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
  public class SPFeatureDefinitionCollector : ComponentCollector
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

    public FeatureDefinitionDescriptor Process(SPFeatureDefinition componentToProcess)
    {
      FeatureDefinitionDescriptor model = new FeatureDefinitionDescriptor(componentToProcess.Id, componentToProcess.Name, String.Empty);     

      

      model.DisplayName = componentToProcess.GetTitle(System.Threading.Thread.CurrentThread.CurrentCulture);
      model.CompatibilityLevel = componentToProcess.CompatibilityLevel;
      model.IsHidden = componentToProcess.Hidden;
      model.Description = componentToProcess.GetDescription(System.Threading.Thread.CurrentThread.CurrentCulture);

      return model;
    }
  }
}
