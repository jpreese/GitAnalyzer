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

        public Author Author { get; private set; }

        public DateTimeOffset Date { get; private set; }

        public IReadOnlyCollection<SourceFile> SourceFiles { get; private set; }
    }
}
