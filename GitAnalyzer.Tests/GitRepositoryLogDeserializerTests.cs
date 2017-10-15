using System;
using Xunit;

namespace GitAnalyzer.Tests
{
    public class GitRepositoryLogDeserializerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Deserialize_NullOrEmptyLogFile_ThrowsArgumentException(string logFile)
        {
            var sut = MakeGitRepositoryLogDeserializer();

            Assert.Throws<ArgumentException>(() => sut.Deserialize(logFile));
        }

        [Fact]
        public void Deserialize_BadLogFileExtension_ThrowsArgumentException()
        {
            var sut = MakeGitRepositoryLogDeserializer();
            var logFile = "foo.bar";

            Assert.Throws<ArgumentException>(() => sut.Deserialize(logFile));
        }

        [Theory]
        [InlineData("foo.txt")]
        [InlineData("foo.TXT")]
        public void Deserialize_UpperAndLowercaseExtension_DoesNotThrowException(string logFile)
        {
            var sut = MakeGitRepositoryLogDeserializer();

            var repository = sut.Deserialize(logFile);
        }

        private GitRepositoryLogDeserializer MakeGitRepositoryLogDeserializer()
        {
            return new GitRepositoryLogDeserializer();
        }
    }
}
