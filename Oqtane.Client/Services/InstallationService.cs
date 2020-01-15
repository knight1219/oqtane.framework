using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Oqtane.Shared;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class InstallationService : HttpService<GenericResponse>, IInstallationService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public InstallationService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager):base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public override string ApiUrl
        {
            get { return CreateApiUrl(sitestate.Alias, NavigationManager.Uri, "Installation"); }
        }

        public async Task<GenericResponse> IsInstalled()
        {
            return await http.GetJsonAsync<GenericResponse>(this.ApiUrl + "/installed");
        }

        public async Task<GenericResponse> Install(string connectionstring)
        {
            return await http.PostJsonAsync<GenericResponse>(this.ApiUrl, connectionstring);
        }

        public async Task<GenericResponse> Upgrade()
        {
            return await http.GetJsonAsync<GenericResponse>(this.ApiUrl + "/upgrade");
        }
    }
}
