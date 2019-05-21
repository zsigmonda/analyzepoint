using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Unpacker
{
  public interface IPackageUnpacker
  {
    System.IO.DirectoryInfo ExtractAll(string packageFullFileName, string outputFolderPath = null);
  }
}
