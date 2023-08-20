using System.Linq.Expressions;
using Transfer.Business.Abstract;
using Transfer.Core.DataAccess.EntityFramework;
using Transfer.DataAccess.Abstract;
using Transfer.DataAccess.Concrete;
using Transfer.Entity;

namespace Transfer.Business.Concrete
{
    public class BookManager : EfQueryableRepository<TransferContext, Books>, IBookService
    {
        private readonly IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        public async Task<Books> CreateAsync(Books entity)
        {
           return await _bookDal.CreateAsync(entity);
        }

        public Task DeleteAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Books>> GetAllAsync(Expression<Func<Books, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Books> GetAsync(Expression<Func<Books, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Books entity)
        {
            throw new NotImplementedException();
        }
    }
}
