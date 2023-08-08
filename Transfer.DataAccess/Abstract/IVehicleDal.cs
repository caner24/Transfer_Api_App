using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.DataAcess;
using Transfer.Entity;

namespace Transfer.DataAccess.Abstract
{
    public interface IVehicleDal:IEntityRepository<Vehicle>
    {
    }
}
