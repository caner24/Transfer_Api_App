using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Core.DataAcess
{
    public interface IEntityRepository<TEntity> where TEntity : class,IEntity,new()
    {
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
