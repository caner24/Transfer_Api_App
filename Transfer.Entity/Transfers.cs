using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Entity
{
    public class Transfers:IEntity
    {
        public double TotalAmount { get; set; }
        public string BookingStatusType { get; set; }
        public int VehicleId { get; set; }
    }
}
