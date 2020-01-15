using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetPages();
        IEnumerable<Page> GetPages(int SiteId);
        Page AddPage(Page Page);
        Page UpdatePage(Page Page);
        Page GetPage(int PageId);
        Page GetPage(int PageId, int UserId);
        void DeletePage(int PageId);
    }
}
