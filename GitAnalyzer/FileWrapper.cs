using System.IO;

namespace GitAnalyzer
{
    public class FileWrapper : IFileWrapper
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
