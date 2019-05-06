using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzePoint.Core.Common;

namespace AnalyzePoint.Core.Model
{
  public class WebServiceDescriptor : ServiceDescriptor, IFeatureTarget
  {
    /// <summary>
    /// This list contains all the features activated at farm level. When a new feature descriptor is added to this list, the target of the feature will be automatically set.
    /// </summary>
    public ObservableCollection<FeatureDescriptor> Features { get; protected set; }

    /// <summary>
    /// This list contains all the web applications within a farm.
    /// </summary>
    public List<WebApplicationDescriptor> WebApplications { get; protected set; }

    public WebServiceDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      ServiceType = ServiceType.ContentService;

      Features = new ObservableCollection<FeatureDescriptor>();
      Features.CollectionChanged += FeatureCollectionChanged;
      this.WebApplications = new List<WebApplicationDescriptor>();
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
