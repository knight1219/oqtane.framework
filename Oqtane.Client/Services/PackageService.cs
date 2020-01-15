using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Shared;
using System.Linq;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class PackageService : HttpService<Package>, IPackageService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public PackageService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public async Task<List<Package>> GetPackagesAsync(string Tag)
        {
            List<Package> packages = await http.GetJsonAsync<List<Package>>(this.ApiUrl + "?tag=" + Tag);
            return packages.OrderByDescending(item => item.Downloads).ToList();
        }

        public async Task DownloadPackageAsync(string PackageId, string Version, string Folder)
        {
            await http.PostJsonAsync(this.ApiUrl + "?packageid=" + PackageId + "&version=" + Version + "&folder=" + Folder, null);
        }
    }
}
