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
    public class ProfileService : HttpService<Profile>, IProfileService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public ProfileService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<List<Profile>> GetProfilesAsync()
        {
            return await http.GetJsonAsync<List<Profile>>(this.ApiUrl);
        }

        public async Task<List<Profile>> GetProfilesAsync(int SiteId)
        {
            List<Profile> Profiles = await http.GetJsonAsync<List<Profile>>(this.ApiUrl + "?siteid=" + SiteId.ToString());
            return Profiles.OrderBy(item => item.ViewOrder).ToList();
        }

        public async Task<Profile> GetProfileAsync(int ProfileId)
        {
            return await http.GetJsonAsync<Profile>(this.ApiUrl + "/" + ProfileId.ToString());
        }

        public async Task<Profile> AddProfileAsync(Profile Profile)
        {
            return await http.PostJsonAsync<Profile>(this.ApiUrl, Profile);
        }

        public async Task<Profile> UpdateProfileAsync(Profile Profile)
        {
            return await http.PutJsonAsync<Profile>(this.ApiUrl + "/" + Profile.SiteId.ToString(), Profile);
        }
        public async Task DeleteProfileAsync(int ProfileId)
        {
            await http.DeleteAsync(this.ApiUrl + "/" + ProfileId.ToString());
        }
    }
}
