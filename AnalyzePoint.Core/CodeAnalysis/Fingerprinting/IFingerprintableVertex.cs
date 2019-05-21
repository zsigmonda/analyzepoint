using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.CodeAnalysis.Fingerprinting
{
  public interface IFingerprintableVertex
  {
    uint GetLabel();
  }
}
