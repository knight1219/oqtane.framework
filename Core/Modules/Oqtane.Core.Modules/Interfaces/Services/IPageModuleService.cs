using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IPageModuleService : IHttpService<PageModule>
    {
        Task<PageModule> GetPageModuleAsync(int PageId, int ModuleId);
        Task UpdatePageModuleOrderAsync(int PageId, string Pane);
    }
}
