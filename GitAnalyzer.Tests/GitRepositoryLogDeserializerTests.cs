using Moq;
using Xunit;

namespace GitAnalyzer.Tests
{
    public class GitRepositoryLogDeserializerTests
    {
        [Fact]
        public void Deserialize_ByDefault_CallsGetAuthor()
        {
            var _repositoryLogParser = new Mock<IRepositoryLogParser>();
            var sut = new GitRepositoryLogDeserializer(_repositoryLogParser.Object);

            var repository = sut.Deserialize();

            _repositoryLogParser.Verify(m => m.GetAuthor());
        }
    }
}
