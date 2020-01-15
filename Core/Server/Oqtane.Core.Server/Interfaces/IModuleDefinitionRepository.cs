using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IModuleDefinitionRepository
    {
        IEnumerable<ModuleDefinition> GetModuleDefinitions(int SideId);
        void UpdateModuleDefinition(ModuleDefinition ModuleDefinition);
        void DeleteModuleDefinition(int ModuleDefinitionId, int SiteId);

    }
}
