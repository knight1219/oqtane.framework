using Oqtane.Core.Modules.Interfaces.Services;
using Oqtane.Core.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IProfileService : IHttpService<Profile>
    {
        Task<List<Profile>> GetProfilesAsync();

        Task<List<Profile>> GetProfilesAsync(int SiteId);

        Task<Profile> GetProfileAsync(int ProfileId);

        Task<Profile> AddProfileAsync(Profile Profile);

        Task<Profile> UpdateProfileAsync(Profile Profile);

        Task DeleteProfileAsync(int ProfileId);
    }
}
