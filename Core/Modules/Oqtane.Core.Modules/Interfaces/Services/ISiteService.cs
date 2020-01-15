using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface ISiteService : IHttpService<Site>
    {
        Task<List<Site>> GetSitesAsync();
        Task<List<Site>> GetSitesAsync(Alias Alias);

        Task<Site> GetSiteAsync(int SiteId);
        Task<Site> GetSiteAsync(int SiteId, Alias Alias);

        Task<Site> AddSiteAsync(Site Site);
        Task<Site> AddSiteAsync(Site Site, Alias Alias);

        Task<Site> UpdateSiteAsync(Site Site);
        Task<Site> UpdateSiteAsync(Site Site, Alias Alias);

        Task DeleteSiteAsync(int SiteId);
        Task DeleteSiteAsync(int SiteId, Alias Alias);
    }
}
