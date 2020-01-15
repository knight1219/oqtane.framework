using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IJobLogRepository
    {
        IEnumerable<JobLog> GetJobLogs();
        JobLog AddJobLog(JobLog JobLog);
        JobLog UpdateJobLog(JobLog JobLog);
        JobLog GetJobLog(int JobLogId);
        void DeleteJobLog(int JobLogId);
    }
}
