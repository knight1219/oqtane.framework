using Oqtane.Core.Modules.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Core.Shared.Interfaces.Services
{
    public interface IFileService : IHttpService<string>
    {
        Task<List<string>> GetFilesAsync(string Folder);
        Task<string> UploadFilesAsync(string Folder, string[] Files, string FileUploadName);
        Task DeleteFileAsync(string Folder, string File);
    }
}
