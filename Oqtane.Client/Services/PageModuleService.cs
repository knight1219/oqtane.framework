
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Shared;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class PageModuleService : HttpService<PageModule>, IPageModuleService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public PageModuleService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<PageModule> GetPageModuleAsync(int PageId, int ModuleId)
        {
            return await http.GetJsonAsync<PageModule>(this.ApiUrl + "/" + PageId.ToString() + "/" + ModuleId.ToString());
        }

        public async Task UpdatePageModuleOrderAsync(int PageId, string Pane)
        {
            await http.PutJsonAsync(this.ApiUrl + "/?pageid=" + PageId.ToString() + "&pane=" + Pane, null);
        }
    }
}
