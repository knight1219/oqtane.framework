using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Shared;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class UserRoleService : HttpService<UserRole>, IUserRoleService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public UserRoleService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<List<UserRole>> GetUserRolesAsync()
        {
            return await http.GetJsonAsync<List<UserRole>>(this.ApiUrl);
        }

        public async Task<List<UserRole>> GetUserRolesAsync(int SiteId)
        {
            return await http.GetJsonAsync<List<UserRole>>(this.ApiUrl + "?siteid=" + SiteId.ToString());
        }

        public async Task<UserRole> GetUserRoleAsync(int UserRoleId)
        {
            return await http.GetJsonAsync<UserRole>(this.ApiUrl + "/" + UserRoleId.ToString());
        }

        public async Task<UserRole> AddUserRoleAsync(UserRole UserRole)
        {
            return await http.PostJsonAsync<UserRole>(this.ApiUrl, UserRole);
        }

        public async Task<UserRole> UpdateUserRoleAsync(UserRole UserRole)
        {
            return await http.PutJsonAsync<UserRole>(this.ApiUrl + "/" + UserRole.UserRoleId.ToString(), UserRole);
        }

        public async Task DeleteUserRoleAsync(int UserRoleId)
        {
            await http.DeleteAsync(this.ApiUrl + "/" + UserRoleId.ToString());
        }
    }
}
