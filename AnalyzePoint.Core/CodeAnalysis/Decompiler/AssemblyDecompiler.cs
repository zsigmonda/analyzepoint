using AnalyzePoint.Core.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.CodeAnalysis.Decompiler
{
  public class AssemblyDecompiler
  {
    public DirectoryInfo Decompile(string assemblyFullFileName, string outputFolderPath = null)
    {
      if (String.IsNullOrEmpty(assemblyFullFileName))
      {
        throw new ArgumentNullException(nameof(assemblyFullFileName));
      }

      if (!File.Exists(assemblyFullFileName))
      {
        throw new FileNotFoundException("WSP file not found.", assemblyFullFileName);
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
          throw new Exception("Could not create temporary folder for .NET assembly decompilation.");
        }
      }
      else
      {
        tempFolderName = outputFolderPath;
      }

      DirectoryInfo returnValue = Directory.CreateDirectory(tempFolderName);

      var wholeProjectDecompiler = new ICSharpCode.Decompiler.CSharp.WholeProjectDecompiler();
      var assemblyResolver = new ICSharpCode.Decompiler.Metadata.UniversalAssemblyResolver(assemblyFullFileName, true, string.Empty);

      using (var peFile = new ICSharpCode.Decompiler.Metadata.PEFile(assemblyFullFileName))
      {
        wholeProjectDecompiler.AssemblyResolver = assemblyResolver;
        wholeProjectDecompiler.DecompileProject(peFile, returnValue.FullName);

        peFile.Dispose();
      }

      return returnValue;
    }
  }
}
