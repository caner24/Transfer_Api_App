using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.DataAccess;
using Transfer.Entity;

namespace Transfer.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
    }
}
