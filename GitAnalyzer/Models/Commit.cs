using System.Collections.Generic;

namespace GitAnalyzer.Models
{
    public class Commit
    {
        public Commit(IReadOnlyCollection<SourceFile> sourceFiles)
        {
            SourceFiles = sourceFiles;
        }

        public IReadOnlyCollection<SourceFile> SourceFiles { get; private set; }
    }
}
