using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface ISiteRepository
    {
        IEnumerable<Site> GetSites();
        Site AddSite(Site Site);
        Site UpdateSite(Site Site);
        Site GetSite(int SiteId);
        void DeleteSite(int SiteId);
    }
}
