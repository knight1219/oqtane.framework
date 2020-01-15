using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface ITenantResolver
    {
        Alias GetAlias();
        Tenant GetTenant();
    }
}
