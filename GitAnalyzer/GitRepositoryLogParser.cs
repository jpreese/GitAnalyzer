using GitAnalyzer.Models;
using System;

namespace GitAnalyzer
{
    public class GitRepositoryLogParser : IRepositoryLogParser
    {
        private readonly IFileWrapper _fileWrapper;
        private readonly string _logPath;

        public GitRepositoryLogParser(string logPath, IFileWrapper fileWrapper)
        {
            if(string.IsNullOrEmpty(logPath))
            {
                throw new ArgumentException($"{nameof(logPath)} cannot be null or empty");
            }

            if(!logPath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(logPath)} must end in .txt");
            }

            _logPath = logPath;
            _fileWrapper = fileWrapper;
        }

        public Author GetAuthor()
        {
            var logLines = _fileWrapper.ReadAllLines(_logPath);
            return new Author(logLines[0], "foo@bar.com");
        }
    }
}
