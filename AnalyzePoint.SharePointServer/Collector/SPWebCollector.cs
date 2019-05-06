using AnalyzePoint.Core.Collector;
using AnalyzePoint.Core.Model;
using log4net;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.SharePointServer.Collector
{
  public class SPWebCollector : IDefinitionBoundComponentCollector<SPWebCollector, SiteDescriptor, FeatureDefinitionDescriptor>,
    IRecursiveComponentCollector<SPWebCollector, SiteDescriptor>
  {
    private readonly ILog Logger = LogManager.GetLogger(typeof(SPWebCollector));
    public int RecursionDepthLimit { get; protected set; }
    public bool IsRecursionEnabled { get; protected set; }
    private IEnumerable<FeatureDefinitionDescriptor> FeatureDefinitions;
    private SPFeatureCollector SubsequentSPFeatureCollector;

    public IEnumerable<SiteDescriptor> Process()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<SiteDescriptor> Process(object componentToProcess)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<SiteDescriptor> Process(SPWeb site)
    {
      try
      {
        if (site == null)
          throw new ArgumentNullException(nameof(site));

        return null;
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint websites from SPWeb.", ex);
        throw;
      }
    }

    public IEnumerable<SiteDescriptor> Process(SPSite siteCollection)
    {
      try
      {
        if (siteCollection == null)
          throw new ArgumentNullException(nameof(siteCollection));

        //According to best practices, this will be disposed with the SPSite object
        //See https://docs.microsoft.com/en-us/previous-versions/office/developer/sharepoint-2010/ee557362(v%3Doffice.14)

        SPWeb rootWeb = siteCollection.RootWeb;

        SiteDescriptor model = new SiteDescriptor(rootWeb.ID, rootWeb.Title, rootWeb.Title);
        model.Url = rootWeb.Url;
        model.ContainingSite = null;

        if (SubsequentSPFeatureCollector != null)
        {
          IEnumerable<FeatureDescriptor> features = SubsequentSPFeatureCollector.WithComponentDefinitions(this.FeatureDefinitions).Process(rootWeb);

          foreach (var f in features)
          {
            model.Features.Add(f);
          }
        }

        return new[] { model };
      }
      catch (Exception ex)
      {
        Logger.Error("Error occured during collecting SharePoint websites from SPSiteCollection.", ex);
        throw;
      }
    }


    public SPWebCollector WithComponentDefinitions(IEnumerable<FeatureDefinitionDescriptor> componentDefinitions)
    {
      FeatureDefinitions = componentDefinitions;

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

    public SPWebCollector WithSubsequentCollector(SPFeatureCollector collector)
    {
      this.SubsequentSPFeatureCollector = collector;

      return this;
    }
  }
}
