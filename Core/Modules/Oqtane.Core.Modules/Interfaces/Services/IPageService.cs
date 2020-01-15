using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IPageService : IHttpService<Page>
    {
        Task<List<Page>> GetPagesAsync(int SiteId);
        //Task<Page> GetPageAsync(int PageId);       
        //Task<Page> AddPageAsync(Page Page);
        //Task<Page> UpdatePageAsync(Page Page);      
        //Task DeletePageAsync(int PageId);

        Task UpdatePageOrderAsync(int SiteId, int PageId, int? ParentId);
        Task<Page> GetPageAsync(int PageId, int UserId);
    }
}
