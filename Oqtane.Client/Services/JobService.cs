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
    public class JobService : HttpService<Job>, IJobService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public JobService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }


        public async Task StartJobAsync(int JobId)
        {
            await http.GetAsync(this.ApiUrl + "/start/" + JobId.ToString());
        }

        public async Task StopJobAsync(int JobId)
        {
            await http.GetAsync(this.ApiUrl + "/stop/" + JobId.ToString());
        }
    }
}
