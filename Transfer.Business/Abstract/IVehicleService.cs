using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;
using Transfer.Entity;

namespace Transfer.Business.Abstract
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAll(Expression<Func<Vehicle, bool>> filter = null);
    }
}
