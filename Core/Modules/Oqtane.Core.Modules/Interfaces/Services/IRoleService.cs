using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IRoleService : IHttpService<Role>
    {
        Task<List<Role>> GetRolesAsync();

        Task<List<Role>> GetRolesAsync(int SiteId);

        Task<Role> GetRoleAsync(int RoleId);

        Task<Role> AddRoleAsync(Role Role);

        Task<Role> UpdateRoleAsync(Role Role);

        Task DeleteRoleAsync(int RoleId);
    }
}
