using GitAnalyzer.Models;

namespace GitAnalyzer
{
    public class GitRepositoryLogParser : IRepositoryLogParser
    {
        public GitRepositoryLogParser(string logFile)
        {
        }

        public Author GetAuthor()
        {
            return new Author("Foo Bar", "foo@bar.com");
        }
    }
}
