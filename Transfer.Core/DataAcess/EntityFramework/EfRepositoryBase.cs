using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Core.DataAcess.EntityFramework
{
    public class EfRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? await context.Set<TEntity>().ToListAsync() :await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }
    }
}
