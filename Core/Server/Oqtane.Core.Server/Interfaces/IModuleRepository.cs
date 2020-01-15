using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IModuleRepository
    {
        IEnumerable<Module> GetModules();
        Module AddModule(Module Module);
        Module UpdateModule(Module Module);
        Module GetModule(int ModuleId);
        void DeleteModule(int ModuleId);
    }
}
