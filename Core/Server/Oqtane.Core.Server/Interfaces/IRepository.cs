using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oqtane.Core.Server.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity Add(TEntity entity);

        void Delete(int id);

        TEntity Update(TEntity entity);

        TEntity Get(int id);

        IQueryable<TEntity> GetAll();
    }
}
