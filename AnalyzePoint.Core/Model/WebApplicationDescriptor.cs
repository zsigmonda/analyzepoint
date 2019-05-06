using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class WebApplicationDescriptor : Descriptor, IFeatureTarget
  {
    /// <summary>
    /// This list contains all the Site Collections that belong to this web application.
    /// </summary>
    public List<SiteCollectionDescriptor> SiteCollections { get; protected set; }

    /// <summary>
    /// This list contains all the features activated on this web application. When a new feature descriptor is added to this list, the target of the feature will be automatically set.
    /// </summary>
    public ObservableCollection<FeatureDescriptor> Features { get; protected set; }

    /// <summary>
    /// This list contains all the farm solutions that are deployed for this web application (including globally deployed farm solutions).
    /// </summary>
    public List<SolutionDescriptor> DeployedSolutions { get; protected set; }

    public WebApplicationDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      IsDeployed = true;

      this.SiteCollections = new List<SiteCollectionDescriptor>();
      this.DeployedSolutions = new List<SolutionDescriptor>();

      Features = new ObservableCollection<FeatureDescriptor>();
      Features.CollectionChanged += FeatureCollectionChanged;
    }

    private void FeatureCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
      {
        foreach (var item in e.NewItems)
        {
          FeatureDescriptor fd = item as FeatureDescriptor;
          fd.Target = this;
        }
      }
    }
  }
}
