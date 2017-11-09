using System.Collections.Generic;

namespace GitAnalyzer.Models
{
    public class GitRepository : IRepository
    {
        public GitRepository(IReadOnlyList<Commit> commits)
        {
            Commits = commits;
        }

        public IReadOnlyList<Commit> Commits { get; }
    }
}
