using AnalyzePoint.Core.Configuration;
using Microsoft.Deployment.Compression.Cab;
using System;
using System.IO;

namespace AnalyzePoint.Core.Unpacker
{
  public class WspUnpacker : IPackageUnpacker
  {
    public DirectoryInfo ExtractAll(string packageFullFileName, string outputFolderPath = null)
    {
      if (String.IsNullOrEmpty(packageFullFileName))
      {
        throw new ArgumentNullException(nameof(packageFullFileName));
      }

      if (!File.Exists(packageFullFileName))
      {
        throw new FileNotFoundException("WSP file not found.", packageFullFileName);
      }

      string tempFolderName;
      if (String.IsNullOrEmpty(outputFolderPath))
      {
        tempFolderName = Path.Combine(AnalyzePointConfiguration.Current.TemporaryFolder.Path, Path.GetRandomFileName());

        int retryCount;
        for (retryCount = 4; retryCount > 0 && Directory.Exists(tempFolderName); --retryCount)
        {
          tempFolderName = Path.Combine(AnalyzePointConfiguration.Current.TemporaryFolder.Path, Path.GetRandomFileName());
        }

        if (retryCount == 0)
        {
          throw new Exception("Could not create temporary folder for WSP extraction.");
        }
      }
      else
      {
        tempFolderName = outputFolderPath;
      }

      DirectoryInfo returnValue = Directory.CreateDirectory(tempFolderName);

      CabInfo cabinetInfo = new CabInfo(packageFullFileName);

      cabinetInfo.Unpack(returnValue.FullName);

      return returnValue;
    }
  }
}
