using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IThemeService : IHttpService<Theme>
    {
        Task<List<Theme>> GetThemesAsync();
        Dictionary<string, string> GetThemeTypes(List<Theme> Themes);
        Dictionary<string, string> GetPaneLayoutTypes(List<Theme> Themes, string ThemeName);
        Dictionary<string, string> GetContainerTypes(List<Theme> Themes);
        Task InstallThemesAsync();
        Task DeleteThemeAsync(string ThemeName);
    }
}
