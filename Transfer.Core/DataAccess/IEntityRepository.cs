using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(string Id);
         void  Update(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    }
}
