using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface ITenantService : IHttpService<Tenant>
    {
        Task<List<Tenant>> GetTenantsAsync();

        Task<Tenant> GetTenantAsync(int TenantId);

        Task<Tenant> AddTenantAsync(Tenant Tenant);

        Task<Tenant> UpdateTenantAsync(Tenant Tenant);

        Task DeleteTenantAsync(int TenantId);
    }
}
