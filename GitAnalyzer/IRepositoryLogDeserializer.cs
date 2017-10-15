namespace GitAnalyzer
{
    public interface IRepositoryLogDeserializer
    {
        IRepository Deserialize(string logFile);
    }
}