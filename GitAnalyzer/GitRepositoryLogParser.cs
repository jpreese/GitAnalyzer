using GitAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                DateTimeOffset date;

                if(logLine.StartsWith("Author"))
                {
                    author = ParseAuthor(logLine);
                }

                if(logLine.StartsWith("Date"))
                {
                    date = ParseDate(logLine);
                }

                var commit = new Commit(author, date, null);
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

        private DateTimeOffset ParseDate(string logLine)
        {
            const string DateFormat = "ddd MMM d HH:mm:ss yyyy K";
            var date = logLine.Split("Date:")[1].Trim();

            return DateTimeOffset.ParseExact(date, DateFormat, CultureInfo.InvariantCulture);
        }
    }
}
