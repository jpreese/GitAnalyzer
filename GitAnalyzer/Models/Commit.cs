using System.Collections.Generic;

namespace GitAnalyzer.Models
{
    public class Commit
    {
        public Commit(IReadOnlyCollection<SourceFile> sourceFiles, Author author)
        {
            Author = author;
            SourceFiles = sourceFiles;
        }

        public Author Author { get; private set; }

        public IReadOnlyCollection<SourceFile> SourceFiles { get; private set; }
    }
}
