namespace GitAnalyzer
{
    public interface IFileWrapper
    {
        string[] ReadAllLines(string path);
    }
}
