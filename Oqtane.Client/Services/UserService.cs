using Oqtane.Shared;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Collections.Generic;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class UserService : HttpService<User>, IUserService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public UserService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = await http.GetJsonAsync<List<User>>(this.ApiUrl);
            return users.OrderBy(item => item.DisplayName).ToList();
        }

        public async Task<User> GetUserAsync(int UserId, int SiteId)
        {
            return await http.GetJsonAsync<User>(this.ApiUrl + "/" + UserId.ToString() + "?siteid=" + SiteId.ToString());
        }

        public async Task<User> GetUserAsync(string Username, int SiteId)
        {
            return await http.GetJsonAsync<User>(this.ApiUrl + "/name/" + Username + "?siteid=" + SiteId.ToString());
        }

        public async Task<User> AddUserAsync(User User)
        {
            try
            {
                return await http.PostJsonAsync<User>(this.ApiUrl, User);
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> AddUserAsync(User User, Alias Alias)
        {
            try
            {
                return await http.PostJsonAsync<User>(CreateApiUrl(Alias, NavigationManager.Uri, "User"), User);
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> UpdateUserAsync(User User)
        {
            return await http.PutJsonAsync<User>(this.ApiUrl + "/" + User.UserId.ToString(), User);
        }
        public async Task DeleteUserAsync(int UserId)
        {
            await http.DeleteAsync(this.ApiUrl + "/" + UserId.ToString());
        }

        public async Task<User> LoginUserAsync(User User, bool SetCookie, bool IsPersistent)
        {
            return await http.PostJsonAsync<User>(this.ApiUrl + "/login?setcookie=" + SetCookie.ToString() + "&persistent=" + IsPersistent.ToString(), User);
        }

        public async Task LogoutUserAsync(User User)
        {
            // best practices recommend post is preferrable to get for logout
            await http.PostJsonAsync(this.ApiUrl + "/logout", User); 
        }
    }
}
