namespace GitAnalyzer.Models
{
    public class SourceFile
    {
        public SourceFile(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }

        public string Name { get; private set; }

        public string Extension { get; private set; }
    }
}
