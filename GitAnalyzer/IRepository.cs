using GitAnalyzer.Models;
using System.Collections.Generic;

namespace GitAnalyzer
{
    public interface IRepository
    {
        IReadOnlyList<Commit> Commits { get; }
    }
}