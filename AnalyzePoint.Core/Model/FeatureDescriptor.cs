using System;

namespace AnalyzePoint.Core.Model
{
  public class FeatureDescriptor : Descriptor
  {
    /// <summary>
    /// Contains a reference to a feature definition describing this activated feature.
    /// </summary>
    public FeatureDefinitionDescriptor Definition { get; protected set; }

    /// <summary>
    /// The SharePoint component where this feature is activated.
    /// </summary>
    public Descriptor Target { get; set; }

    /// <summary>
    /// Version of the activated feature.
    /// </summary>
    public Version Version { get; set; }

    public FeatureDescriptor(FeatureDefinitionDescriptor definition) : base(definition.ID, definition.Name, definition.DisplayName)
    {
      Definition = definition;
    }

    public FeatureDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      Definition = null;
    }
  }
}
