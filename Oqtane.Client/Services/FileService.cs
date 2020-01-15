using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Oqtane.Core.Modules;
using Oqtane.Core.Shared.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using Oqtane.Shared;

namespace Oqtane.Services
{
    public class FileService : HttpService<string>, IFileService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly NavigationManager NavigationManager;
        private readonly IJSRuntime jsRuntime;

        public FileService(HttpClient http, SiteState sitestate, NavigationManager NavigationManager, IJSRuntime jsRuntime) : base(http, sitestate, NavigationManager)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.NavigationManager = NavigationManager;
            this.jsRuntime = jsRuntime;
        }

        public override string ApiUrl
        {
            get { return CreateApiUrl(sitestate.Alias, NavigationManager.Uri, "File"); }
        }

        public async Task<List<string>> GetFilesAsync(string Folder)
        {
            return await http.GetJsonAsync<List<string>>(this.ApiUrl + "?folder=" + Folder);
        }

        public async Task<string> UploadFilesAsync(string Folder, string[] Files, string FileUploadName)
        {
            string result = "";

            var interop = new Interop(jsRuntime);
            await interop.UploadFiles(this.ApiUrl + "/upload", Folder, FileUploadName);

            // uploading files is asynchronous so we need to wait for the upload to complete
            bool success = false;
            int attempts = 0;
            while (attempts < 5 && success == false)
            {
                Thread.Sleep(2000); // wait 2 seconds
                result = "";

                List<string> files = await GetFilesAsync(Folder);
                if (files.Count > 0)
                {
                    success = true;
                    foreach (string file in Files)
                    {
                        if (!files.Contains(file))
                        {
                            success = false;
                            result += file + ",";
                        }
                    }
                }
                attempts += 1;
            }
            if (!success)
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }

        public async Task DeleteFileAsync(string Folder, string File)
        {
            await http.DeleteAsync(this.ApiUrl + "?folder=" + Folder + "&file=" + File);
        }
    }
}
