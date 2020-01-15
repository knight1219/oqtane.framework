using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Enums;
using Oqtane.Core.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface ILogService : IHttpService<Log>
    {
        Task<List<Log>> GetLogsAsync(int SiteId, string Level, string Function, int Rows);
        Task<Log> GetLogAsync(int LogId);
        Task Log(int? PageId, int? ModuleId, int? UserId, string category, string feature, LogFunction function, LogLevel level, Exception exception, string message, params object[] args);
    }
}
