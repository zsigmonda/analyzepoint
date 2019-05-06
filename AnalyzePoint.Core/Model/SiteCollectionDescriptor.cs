using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SiteCollectionDescriptor : Descriptor, IFeatureTarget
  {
    /// <summary>
    /// This list contains all the features activated at this site collection. When a new feature descriptor is added to this list, the target of the feature will be automatically set.
    /// </summary>
    public ObservableCollection<FeatureDescriptor> Features { get; protected set; }

    /// <summary>
    /// Specifies the root site of the site collection.
    /// </summary>
    public SiteDescriptor RootSite { get; set; }

    public SiteCollectionDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
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
