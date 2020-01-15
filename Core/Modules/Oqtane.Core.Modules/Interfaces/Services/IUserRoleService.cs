using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IUserRoleService : IHttpService<UserRole>
    {
        Task<List<UserRole>> GetUserRolesAsync();
        Task<List<UserRole>> GetUserRolesAsync(int SiteId);
        Task<UserRole> GetUserRoleAsync(int UserRoleId);
        Task<UserRole> AddUserRoleAsync(UserRole UserRole);
        Task<UserRole> UpdateUserRoleAsync(UserRole UserRole);
        Task DeleteUserRoleAsync(int UserRoleId);
    }
}
