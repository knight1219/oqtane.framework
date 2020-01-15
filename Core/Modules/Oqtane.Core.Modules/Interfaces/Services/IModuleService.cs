using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IModuleService : IHttpService<Module>
    {
        Task<List<Module>> GetModulesAsync(int SiteId);
        //Task<Module> GetModuleAsync(int ModuleId);
        //Task<Module> AddModuleAsync(Module Module);
        //Task<Module> UpdateModuleAsync(Module Module);
        //Task DeleteModuleAsync(int ModuleId);
        Task<bool> ImportModuleAsync(int ModuleId, string Content);
        Task<string> ExportModuleAsync(int ModuleId);
    }
}
