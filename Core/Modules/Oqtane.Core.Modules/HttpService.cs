using Microsoft.AspNetCore.Components;
using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared;
using Oqtane.Core.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Oqtane.Core.Modules
{
    public class HttpService<T> : IHttpService<T>
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;

        public HttpService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
        }

        public virtual string ApiUrl
        {
            get { return CreateApiUrl(sitestate.Alias, NavigationManager.Uri, typeof(T).Name); }
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            return await http.PostJsonAsync<T>(ApiUrl, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await http.DeleteAsync(ApiUrl + "/" + id.ToString());
        }

        public virtual async Task<List<T>> GetAsync()
        {
            List<T> entities = await http.GetJsonAsync<List<T>>(ApiUrl);
            return entities;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await http.GetJsonAsync<T>(ApiUrl + "/" + id.ToString());
        }

        public virtual async Task<T> UpdateAsync(T entity, int id)
        {
            return await http.PutJsonAsync<T>(ApiUrl + "/" + id.ToString(), entity);
        }

        public virtual string CreateApiUrl(Alias alias, string absoluteUri, string serviceName)
        {
            return Utilities.CreateApiUrl(alias, absoluteUri, serviceName);
        }
    }
}
