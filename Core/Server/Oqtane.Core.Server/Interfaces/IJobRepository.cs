using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetJobs();
        Job AddJob(Job Job);
        Job UpdateJob(Job Job);
        Job GetJob(int JobId);
        void DeleteJob(int JobId);
    }
}
