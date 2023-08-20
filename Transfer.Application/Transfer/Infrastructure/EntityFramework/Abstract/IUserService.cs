using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.DataAccess;
using Transfer.Entity;

namespace Transfer.Business.Abstract
{
    public interface IUserService : IQueryableRepository<User>
    {
        Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null);
        Task<User> CreateAsync(User entity);
        Task DeleteAsync(string Id);
        void Update(User entity);
        Task<User> GetAsync(Expression<Func<User, bool>> filter);
    }
}
