using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPWebCollector : ITargetedComponentCollector<SPWebCollector, SiteDescriptor>,
    IDefinitionBoundComponentCollector<SPWebCollector, SiteDescriptor, FeatureDefinitionDescriptor>,
    IRecursiveComponentCollector<SPWebCollector, SiteDescriptor>
  {
    public int RecursionDepthLimit { get; protected set; }
    public bool IsRecursionEnabled { get; protected set; }
    private IEnumerable<FeatureDefinitionDescriptor> ComponentDefinitions;
    private SPWeb ComponentToProcess;

    public SPWebCollector ForComponent(object componentToProcess)
    {
      ComponentToProcess = componentToProcess as SPWeb;

      return this;
    }

    public IEnumerable<SiteDescriptor> Process()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<SiteDescriptor> Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public SPWebCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      ComponentDefinitions = componentDefinitions;

      return this;
    }

    public SPWebCollector WithoutRecursion()
    {
      IsRecursionEnabled = false;

      return this;
    }

    public SPWebCollector WithRecursion()
    {
      return WithRecursion(0);
    }

    public SPWebCollector WithRecursion(int depthLimit)
    {
      RecursionDepthLimit = depthLimit;
      IsRecursionEnabled = true;

      return this;
    }
  }
}
