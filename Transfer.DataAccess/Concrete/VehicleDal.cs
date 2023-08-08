using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.DataAccess;
using Transfer.Core.DataAccess.EntityFramework;
using Transfer.DataAccess.Abstract;
using Transfer.Entity;

namespace Transfer.DataAccess.Concrete
{
    public class VehicleDal:EfRepositoryBase<TransferContext,Vehicle>,IVehicleDal
    {

    }
}
