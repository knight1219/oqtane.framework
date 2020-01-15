using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IAliasRepository
    {
        IEnumerable<Alias> GetAliases();
        Alias AddAlias(Alias Alias);
        Alias UpdateAlias(Alias Alias);
        Alias GetAlias(int AliasId);
        void DeleteAlias(int AliasId);
    }
}
