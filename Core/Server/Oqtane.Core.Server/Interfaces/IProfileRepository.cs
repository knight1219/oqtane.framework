using System.Collections.Generic;
using Oqtane.Core.Shared.Models;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IProfileRepository
    {
        IEnumerable<Profile> GetProfiles();
        IEnumerable<Profile> GetProfiles(int SiteId);
        Profile AddProfile(Profile Profile);
        Profile UpdateProfile(Profile Profile);
        Profile GetProfile(int ProfileId);
        void DeleteProfile(int ProfileId);
    }
}
