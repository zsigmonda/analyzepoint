using AnalyzePoint.Core.Common;
using System;
using System.Collections.Generic;

namespace AnalyzePoint.Core.Model
{
  public class FeatureDefinitionDescriptor : Descriptor
  {
    public FeatureScope Scope { get; set; }

    /// <summary>
    /// Contains a reference to the farm solution, in which this feature definition is hosted. For system built-in feature definitions, this value is null.
    /// </summary>
    public SolutionDescriptor ContainingSolution { get; set; }

    /// <summary>
    /// Specifies whether the feature definition is a built-in system feature definition or a custom-built one.
    /// </summary>
    public bool IsBuiltIn
    {
      get
      {
        return ContainingSolution == null;
      }
    }

    /// <summary>
    /// Returns the compatibility level of the feature.
    /// </summary>
    public int CompatibilityLevel { get; set; }

    /// <summary>
    /// Specifies whether the feature is visible on the web-based UI.
    /// </summary>
    public bool IsHidden { get; set; }

    /// <summary>
    /// The description of the feature, localized to the current thread.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The version of the feature.
    /// </summary>
    public Version Version { get; set; }

    /// <summary>
    /// This list contains all the activated instances (features) of this feature definition.
    /// </summary>
    public List<FeatureDescriptor> Instances { get; protected set; }

    public FeatureDefinitionDescriptor(Guid id, string name, string displayName) : base(id, name, displayName)
    {
      Instances = new List<FeatureDescriptor>();
    }
  }
}
