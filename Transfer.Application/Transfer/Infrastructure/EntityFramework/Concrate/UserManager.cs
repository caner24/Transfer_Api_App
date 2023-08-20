using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Core.DataAccess.EntityFramework;
using Transfer.DataAccess.Abstract;
using Transfer.DataAccess.Concrete;
using Transfer.Entity;

namespace Transfer.Business.Concrete
{
    public class UserManager : EfQueryableRepository<TransferContext, User>, IUserService
    {
        private readonly ICacheManager _cache;
        private readonly IUserDal _userDal;
        public UserManager(ICacheManager cache, IUserDal userDal)
        {
            _cache = cache;
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
            if (_cache.IsAdd("userDetail"))
            {
                return await _userDal.GetAllAsync();
            }
            _cache.Add("userDetail", await _userDal.GetAllAsync(), 60);
            return _cache.Get<List<User>>("userDetail");
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
