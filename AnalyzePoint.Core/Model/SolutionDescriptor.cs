﻿using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  public class SolutionDescriptor : BaseDescriptor
  {
    /// <summary>
    /// This list contains all the feature definitions that are embedded into this farm solution.
    /// </summary>
    public List<FeatureDefinitionDescriptor> Features { get; protected set; }

    /// <summary>
    /// This list contains all the web applications where this farm solution is deployed to.
    /// </summary>
    public List<WebApplicationDescriptor> DeployedTo { get; protected set; }

    public bool IsGloballyDeployed { get; set; } 

    public SolutionDescriptor(Guid identifier) : base(identifier)
    {
      this.Features = new List<FeatureDefinitionDescriptor>();
      this.DeployedTo = new List<WebApplicationDescriptor>();
    }
  }
}
