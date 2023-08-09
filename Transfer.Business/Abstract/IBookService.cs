using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.DataAccess;
using Transfer.Core.Entity;
using Transfer.Entity;

namespace Transfer.Business.Abstract
{
    public  interface IBookService: IQueryableRepository<Books>
    {
        Task<List<Books>> GetAllAsync(Expression<Func<Books, bool>> filter = null);
        Task<Books> CreateAsync(Books entity);
        Task DeleteAsync(string Id);
        void Update(Books entity);
        Task<Books> GetAsync(Expression<Func<Books, bool>> filter);
    }
}
