using Moq;
using System;
using System.Globalization;
using System.Linq;
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
        public void Parse_SingleCommitLogLine_AddsCommitToCollection()
        {
            var fileWrapper = new Mock<IFileWrapper>();
            var sut = new GitRepositoryLogParser("foo.txt", fileWrapper.Object);
            var authorLogLine = new string[]
            {
                "commit abcde12345abcde12345abcde12345abcde12345",
            };

            fileWrapper.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(authorLogLine);

            var repository = sut.Parse();

            Assert.Equal(1, repository.Commits.Count);
        }

        [Fact]
        public void Parse_AuthorLine_ReturnsCorrectAuthorName()
        {
            var fileWrapper = new Mock<IFileWrapper>();
            var sut = new GitRepositoryLogParser("foo.txt", fileWrapper.Object);
            var authorLogLine = new string[]
            {
                "Author: Foo Bar <foo@bar.com>",
            };

            fileWrapper.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(authorLogLine);

            var repository = sut.Parse();

            Assert.Equal("Foo Bar", repository.Commits.First().Author.Name);
        }

        [Fact]
        public void Parse_AuthorLine_ReturnsCorrectAuthorEmail()
        {
            var fileWrapper = new Mock<IFileWrapper>();
            var sut = new GitRepositoryLogParser("foo.txt", fileWrapper.Object);
            var authorLogLine = new string[]
            {
                "Author: Foo Bar <foo@bar.com>",
            };

            fileWrapper.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(authorLogLine);

            var repository = sut.Parse();

            Assert.Equal("foo@bar.com", repository.Commits.First().Author.Email);
        }

        [Fact]
        public void Parse_DateLine_ReturnsCorrectCommitDate()
        {
            var fileWrapper = new Mock<IFileWrapper>();
            var sut = new GitRepositoryLogParser("foo.txt", fileWrapper.Object);

            const string DateString = "Thu May 4 20:49:19 2017 +0100";
            var date = new DateTimeOffset();
            
            var authorLogLine = new string[]
            {
                $"Date:   {DateString}",
            };

            fileWrapper.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(authorLogLine);

            var repository = sut.Parse();

            Assert.Equal(date, repository.Commits.First().Date);
        }
    }
}

