using System;
using System.Collections.Generic;
using System.DomainModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    public abstract class DbRepository<TDbContext>
        where TDbContext : DbContext
    {
        protected readonly TDbContext context;

        protected DbRepository(TDbContext context)
        {
            this.context = context;
        }
    }

    public abstract class DbRepository<TDbContext, TEntity> : DbRepository<TDbContext>, IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : Entity
    {
        protected DbRepository(TDbContext context)
            : base(context)
        {

        }

        public virtual async Task Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public virtual async Task AddRange(TEntity[] entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public virtual async Task Update(TEntity entity)
        {
            //context.Entry(entity).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public virtual async Task Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }
    }
}
