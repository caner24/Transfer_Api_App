using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Entity
{
    public class Books
    {

        public Guid Pnr { get; set; }
        public int VehicleId { get; set; }
        public double TotalAmount { get; set; }
        public string BookingStatusTytpe { get; set; }
        public User User { get; set; }
        public Transfers Transfer { get; set; }
    }
}
