using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                context.SaveChanges();
                return entity;
            }
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().AsNoTracking().Where(filter).FirstOrDefaultAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? await context.Set<TEntity>().AsNoTracking().ToListAsync() : await context.Set<TEntity>().AsNoTracking().Where(filter).ToListAsync();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
            }
        }

        public async Task DeleteAsync(string Id)
        {
            using (TContext context = new TContext())
            {
                var deletedProduct = await context.Set<TEntity>().FindAsync(Id);
                context.Remove(deletedProduct);
                context.SaveChanges();
            }
        }
    }
}
