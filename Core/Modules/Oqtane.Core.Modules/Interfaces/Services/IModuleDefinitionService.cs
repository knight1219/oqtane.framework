using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IModuleDefinitionService
    {
        Task<List<ModuleDefinition>> GetModuleDefinitionsAsync(int SiteId);
        Task UpdateModuleDefinitionAsync(ModuleDefinition ModuleDefinition);
        Task InstallModuleDefinitionsAsync();
        Task DeleteModuleDefinitionAsync(int ModuleDefinitionId, int SiteId);
    }
}
