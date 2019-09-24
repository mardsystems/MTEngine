using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DomainModel
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task AddRange(TEntity[] entities);

        Task Update(TEntity entity);

        Task Remove(TEntity entity);
    }
}
