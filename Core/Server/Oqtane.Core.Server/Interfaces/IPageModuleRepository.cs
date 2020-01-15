using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IPageModuleRepository
    {
        IEnumerable<PageModule> GetPageModules();
        IEnumerable<PageModule> GetPageModules(int SiteId);
        PageModule AddPageModule(PageModule PageModule);
        PageModule UpdatePageModule(PageModule PageModule);
        PageModule GetPageModule(int PageModuleId);
        PageModule GetPageModule(int PageId, int ModuleId);
        void DeletePageModule(int PageModuleId);
    }
}
