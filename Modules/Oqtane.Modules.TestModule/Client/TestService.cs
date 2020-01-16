using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Core.Modules;
using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Module.TestModule.Client
{
    public interface ITestService : IHttpService<string>
    {
        Task<string> Get();
    }

    public class TestService : HttpService<string>, ITestService
    {
        private readonly HttpClient _http;
        private readonly SiteState _sitestate;
        private readonly NavigationManager _navigationManager;

        public TestService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            _http = http;
            _sitestate = sitestate;
            _navigationManager = NavigationManager;
        }

        public async Task<string> Get()
        {
            return await _http.GetStringAsync(this.ApiUrl);
        }
    }
}