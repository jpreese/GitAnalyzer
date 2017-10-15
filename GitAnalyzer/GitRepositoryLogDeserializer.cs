using System;

namespace GitAnalyzer
{
    public class GitRepositoryLogDeserializer : IRepositoryLogDeserializer
    {
        public IRepository Deserialize(string logFile)
        {
            if(string.IsNullOrEmpty(logFile))
            {
                throw new ArgumentException($"{nameof(logFile)} cannot be null or empty.");
            }

            if(!logFile.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(logFile)} uses wrong file extension.");
            }

            return null;
        }
    }
}
