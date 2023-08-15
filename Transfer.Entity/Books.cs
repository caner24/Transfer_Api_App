using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Entity
{
    public class Books : IEntity
    {
        public Guid BookId { get; set; }
        public string VehicleIds { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string Pnr { get; set; }
        public double TotalAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
