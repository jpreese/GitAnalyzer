namespace GitAnalyzer
{
    public class GitRepositoryLogDeserializer : IRepositoryLogDeserializer
    {
        private readonly IRepositoryLogParser _repositoryLogParser;

        public GitRepositoryLogDeserializer(IRepositoryLogParser repositoryLogParser)
        {
            _repositoryLogParser = repositoryLogParser;
        }

        public IRepository Deserialize()
        {
            var author = _repositoryLogParser.GetAuthor();

            return null;
        }
    }
}
