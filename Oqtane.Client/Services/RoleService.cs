using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Oqtane.Shared;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class RoleService : HttpService<Role>, IRoleService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public RoleService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            List<Role> Roles = await http.GetJsonAsync<List<Role>>(this.ApiUrl);
            return Roles.OrderBy(item => item.Name).ToList();
        }

        public async Task<List<Role>> GetRolesAsync(int SiteId)
        {
            List<Role> Roles = await http.GetJsonAsync<List<Role>>(this.ApiUrl + "?siteid=" + SiteId.ToString());
            return Roles.OrderBy(item => item.Name).ToList();
        }

        public async Task<Role> GetRoleAsync(int RoleId)
        {
            return await http.GetJsonAsync<Role>(this.ApiUrl + "/" + RoleId.ToString());
        }

        public async Task<Role> AddRoleAsync(Role Role)
        {
            return await http.PostJsonAsync<Role>(this.ApiUrl, Role);
        }

        public async Task<Role> UpdateRoleAsync(Role Role)
        {
            return await http.PutJsonAsync<Role>(this.ApiUrl + "/" + Role.SiteId.ToString(), Role);
        }
        public async Task DeleteRoleAsync(int RoleId)
        {
            await http.DeleteAsync(this.ApiUrl + "/" + RoleId.ToString());
        }
    }
}
