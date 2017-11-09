using System;
using System.Collections.Generic;

namespace GitAnalyzer.Models
{
    public class Commit
    {
        public Commit(Author author, DateTimeOffset date, IReadOnlyCollection<SourceFile> sourceFiles)
        {
            Author = author;
            Date = date;
            SourceFiles = sourceFiles;
        }

        public Author Author { get; }

        public DateTimeOffset Date { get; }

        public IReadOnlyCollection<SourceFile> SourceFiles { get; }
    }
}
