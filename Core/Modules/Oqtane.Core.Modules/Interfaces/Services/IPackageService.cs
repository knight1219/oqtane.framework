using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IPackageService : IHttpService<Package>
    {
        Task<List<Package>> GetPackagesAsync(string Tag);
        Task DownloadPackageAsync(string PackageId, string Version, string Folder);
    }
}
