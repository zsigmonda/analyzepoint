using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SiteDescriptor : SiteContentDescriptor, IFeatureTarget
  {
    public List<SiteContentDescriptor> Contents { get; protected set; }

    /// <summary>
    /// This list contains all the features activated at this site. When a new feature descriptor is added to this list, the target of the feature will be automatically set.
    /// </summary>
    public ObservableCollection<FeatureDescriptor> Features { get; protected set; }

    public string Url { get; set; }

    public SiteDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      Contents = new List<SiteContentDescriptor>();
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

    public void AddContent(SiteContentDescriptor content)
    {
      Contents.Add(content);
      content.ContainingSite = this;
    }

    public void RemoveContent(SiteContentDescriptor content)
    {
      if (Contents.Remove(content))
      {
        content.ContainingSite = null;
      }
    }
  }
}
