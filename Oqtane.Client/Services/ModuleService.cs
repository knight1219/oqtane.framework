using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Modules;
using Module = Oqtane.Core.Shared.Models.Module;

namespace Oqtane.Services
{
    public class ModuleService : HttpService<Oqtane.Core.Shared.Models.Module>, IModuleService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public ModuleService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<List<Oqtane.Core.Shared.Models.Module>> GetModulesAsync(int SiteId)
        {
            List<Oqtane.Core.Shared.Models.Module> modules = await http.GetJsonAsync<List<Oqtane.Core.Shared.Models.Module>>(this.ApiUrl + "?siteid=" + SiteId.ToString());
            modules = modules
                .OrderBy(item => item.Order)
                .ToList();
            return modules;
        }

        public async Task<bool> ImportModuleAsync(int ModuleId, string Content)
        {
            return await http.PostJsonAsync<bool>(this.ApiUrl + "/import?moduleid=" + ModuleId, Content);
        }

        public async Task<string> ExportModuleAsync(int ModuleId)
        {
            return await http.GetStringAsync(this.ApiUrl + "/export?moduleid=" + ModuleId.ToString());
        }
    }
}
