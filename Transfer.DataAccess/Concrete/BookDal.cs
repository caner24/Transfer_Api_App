using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.DataAccess.EntityFramework;
using Transfer.Entity;

namespace Transfer.DataAccess.Concrete
{
    public class BookDal:EfRepositoryBase<TransferContext,Books>
    {
    }
}
