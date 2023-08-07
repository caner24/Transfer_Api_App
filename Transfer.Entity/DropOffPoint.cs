using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Entity
{
    public class DropOffPoint : PointBase, IEntity
    {
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
