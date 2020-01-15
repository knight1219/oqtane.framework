using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IInstallationService : IHttpService<GenericResponse>
    {
        Task<GenericResponse> IsInstalled();
        Task<GenericResponse> Install(string connectionstring);
        Task<GenericResponse> Upgrade();
    }
}
