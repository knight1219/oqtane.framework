using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Modules;

namespace Oqtane.Services
{
    public class AliasService : HttpService<Alias>, IAliasService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public AliasService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager):base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }
    }
}
