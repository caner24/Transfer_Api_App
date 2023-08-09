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
    public class BookManager : EfQueryableRepository<TransferContext, Books>, IBookService
    {
        private readonly IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        public Task<Books> CreateAsync(Books entity)
        {
            throw new NotImplementedException();
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
