using Oqtane.Core.Shared.Models;
using System.Collections.Generic;

namespace Oqtane.Core.Server.Interfaces
{
    public interface ITenantRepository
    {
        IEnumerable<Tenant> GetTenants();
        Tenant AddTenant(Tenant Tenant);
        Tenant UpdateTenant(Tenant Tenant);
        Tenant GetTenant(int TenantId);
        void DeleteTenant(int TenantId);
    }
}
