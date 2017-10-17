using Moq;
using System;
using Xunit;

namespace GitAnalyzer.Tests
{
    public class GitRepositoryLogParserTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_NullOrEmptyPath_ThrowsArgumentException(string path)
        {
            var fileWrapper = new Mock<IFileWrapper>();

            Assert.Throws<ArgumentException>(() => new GitRepositoryLogParser(path, fileWrapper.Object));
        }

        [Theory]
        [InlineData("foo.txt")]
        [InlineData("foo.TXT")]
        public void Constructor_UpperOrLowercaseTxtExtension_DoesNotThrowException(string path)
        {
            var fileWrapper = new Mock<IFileWrapper>();
            var parser = new GitRepositoryLogParser(path, fileWrapper.Object);
        }

        [Fact]
        public void GetAuthor_ByDefault_ReturnsAuthor()
        {
            var fileWrapper = new Mock<IFileWrapper>();
            var sut = new GitRepositoryLogParser("foo.txt", fileWrapper.Object);
            var logLines = new string[]
            {
                "Foo Bar"
            };

            fileWrapper.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(logLines);

            var author = sut.GetAuthor();

            Assert.Equal("Foo Bar", author.Name);
        }
    }
}
