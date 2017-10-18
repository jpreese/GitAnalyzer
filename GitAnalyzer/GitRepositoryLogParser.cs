using GitAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public IRepository Parse()
        {
            var commits = new List<Commit>();

            var logLines = _fileWrapper.ReadAllLines(_logPath);
            foreach(var logLine in logLines)
            {
                Author author = null;

                if(logLine.StartsWith("Author"))
                {
                    author = ParseAuthor(logLine);
                }

                var commit = new Commit(null, author);
                commits.Add(commit);
            }

            return new GitRepository(commits);
        }

        private Author ParseAuthor(string logLine)
        {
            var authorName = ParseAuthorName(logLine);
            var authorEmail = ParseAuthorEmail(logLine);

            return new Author(authorName, authorEmail);
        }

        private string ParseAuthorName(string logLine)
        {
            var authorNameRegex = new Regex(@"(?<=\: )(.*?)(?=\ <)");
            var authorNameResult = authorNameRegex.Matches(logLine).First().ToString();

            return authorNameResult;
        }

        private string ParseAuthorEmail(string logLine)
        {
            var authorEmailRegex = new Regex(@"(?<=\<)(.*?)(?=\>)");
            var authorEmailResult = authorEmailRegex.Matches(logLine).First().ToString();

            return authorEmailResult;
        }
    }
}
