using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Shared;
using System.Collections.Generic;
using System.Linq;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class TenantService : HttpService<Tenant>, ITenantService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public TenantService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<List<Tenant>> GetTenantsAsync()
        {
            List<Tenant> tenants = await http.GetJsonAsync<List<Tenant>>(this.ApiUrl);
            return tenants.OrderBy(item => item.Name).ToList();
        }

        public async Task<Tenant> GetTenantAsync(int TenantId)
        {
            return await http.GetJsonAsync<Tenant>(this.ApiUrl + "/" + TenantId.ToString());
        }

        public async Task<Tenant> AddTenantAsync(Tenant Tenant)
        {
            return await http.PostJsonAsync<Tenant>(this.ApiUrl, Tenant);
        }

        public async Task<Tenant> UpdateTenantAsync(Tenant Tenant)
        {
            return await http.PutJsonAsync<Tenant>(this.ApiUrl + "/" + Tenant.TenantId.ToString(), Tenant);
        }

        public async Task DeleteTenantAsync(int TenantId)
        {
            await http.DeleteAsync(this.ApiUrl + "/" + TenantId.ToString());
        }
    }
}
