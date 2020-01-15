using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Oqtane.Shared;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class SiteService : HttpService<Site>, ISiteService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public SiteService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<List<Site>> GetSitesAsync()
        {
            List<Site> sites = await http.GetJsonAsync<List<Site>>(this.ApiUrl);
            return sites.OrderBy(item => item.Name).ToList();
        }
        public async Task<List<Site>> GetSitesAsync(Alias Alias)
        {
            List<Site> sites = await http.GetJsonAsync<List<Site>>(CreateApiUrl(Alias, NavigationManager.Uri, "Site"));
            return sites.OrderBy(item => item.Name).ToList();
        }

        public async Task<Site> GetSiteAsync(int SiteId)
        {
            return await http.GetJsonAsync<Site>(this.ApiUrl + "/" + SiteId.ToString());
        }
        public async Task<Site> GetSiteAsync(int SiteId, Alias Alias)
        {
            return await http.GetJsonAsync<Site>(CreateApiUrl(Alias, NavigationManager.Uri, "Site") + "/" + SiteId.ToString());
        }

        public async Task<Site> AddSiteAsync(Site Site)
        {
            return await http.PostJsonAsync<Site>(this.ApiUrl, Site);
        }

        public async Task<Site> AddSiteAsync(Site Site, Alias Alias)
        {
            return await http.PostJsonAsync<Site>(CreateApiUrl(Alias, NavigationManager.Uri, "Site"), Site);
        }

        public async Task<Site> UpdateSiteAsync(Site Site)
        {
            return await http.PutJsonAsync<Site>(this.ApiUrl + "/" + Site.SiteId.ToString(), Site);
        }
        public async Task<Site> UpdateSiteAsync(Site Site, Alias Alias)
        {
            return await http.PutJsonAsync<Site>(CreateApiUrl(Alias, NavigationManager.Uri, "Site") + "/" + Site.SiteId.ToString(), Site);
        }

        public async Task DeleteSiteAsync(int SiteId)
        {
            await http.DeleteAsync(this.ApiUrl + "/" + SiteId.ToString());
        }
        public async Task DeleteSiteAsync(int SiteId, Alias Alias)
        {
            await http.DeleteAsync(CreateApiUrl(Alias, NavigationManager.Uri, "Site") + "/" + SiteId.ToString());
        }
    }
}
