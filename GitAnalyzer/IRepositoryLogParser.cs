using GitAnalyzer.Models;

namespace GitAnalyzer
{
    public interface IRepositoryLogParser
    {
        Author GetAuthor();
    }
}
