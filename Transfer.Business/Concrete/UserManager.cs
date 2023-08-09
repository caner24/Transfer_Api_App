using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Core.DataAccess.EntityFramework;
using Transfer.DataAccess.Abstract;
using Transfer.DataAccess.Concrete;
using Transfer.Entity;

namespace Transfer.Business.Concrete
{
    public class UserManager : EfQueryableRepository<TransferContext, User>, IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<User> CreateAsync(User entity)
        {
            return await _userDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(string Id)
        {
             await _userDal.DeleteAsync(Id);
        }

        public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {
            return await _userDal.GetAllAsync(filter);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter)
        {
            return await _userDal.GetAsync(filter);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }

    }
}
