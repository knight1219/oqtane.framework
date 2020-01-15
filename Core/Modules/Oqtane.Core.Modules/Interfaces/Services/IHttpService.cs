using Oqtane.Core.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oqtane.Core.Modules.Interfaces.Services
{
    public interface IHttpService<T>
    {
        string ApiUrl { get; }

        Task<List<T>> GetAsync();

        Task<T> GetAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity, int id);

        Task DeleteAsync(int id);
    }
}
