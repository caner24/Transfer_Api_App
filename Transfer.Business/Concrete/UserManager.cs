using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Core.DataAccess.EntityFramework;
using Transfer.DataAccess.Concrete;
using Transfer.Entity;

namespace Transfer.Business.Concrete
{
    public class UserManager : EfQueryableRepository<TransferContext, User>, IUserService
    {
        private readonly IUserService _userService;
        public UserManager(IUserService _userService)
        {

        }

        public async Task<User> CreateAsync(User entity)
        {
            return await _userService.CreateAsync(entity);
        }

        public async Task DeleteAsync(string Id)
        {
             await _userService.DeleteAsync(Id);
        }

        public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {
            return await _userService.GetAllAsync(filter);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter)
        {
            return await _userService.GetAsync(filter);
        }

        public void Update(User entity)
        {
              _userService.Update(entity);
        }

    }
}
