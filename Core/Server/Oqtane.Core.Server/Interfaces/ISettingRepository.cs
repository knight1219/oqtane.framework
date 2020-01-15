using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface ISettingRepository
    {
        IEnumerable<Setting> GetSettings(string EntityName, int EntityId);
        Setting AddSetting(Setting Setting);
        Setting UpdateSetting(Setting Setting);
        Setting GetSetting(int SettingId);
        void DeleteSetting(int SettingId);
    }
}
