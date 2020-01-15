using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IThemeRepository
    {
        IEnumerable<Theme> GetThemes();
    }
}
