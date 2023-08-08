using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.DataAccess.Abstract;
using Transfer.Entity;

namespace Transfer.Business.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;
        public VehicleService(IVehicleDal vehicleDal)
        {
                _vehicleDal = vehicleDal;   
        }
        public async Task<List<Vehicle>> GetAll(Expression<Func<Vehicle, bool>> filter = null)
        {
           return await _vehicleDal.GetAll(filter);
        }
    }
}
