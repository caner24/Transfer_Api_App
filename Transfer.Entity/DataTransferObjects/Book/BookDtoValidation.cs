using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Entity.DataTransferObjects.Book
{
    public abstract record class BookDtoValidation
    {
        public string VehicleIds { get; init; }
        public int Adults { get; init; }
        public int Children { get; init; }
        public string Pnr { get; init; }
        public double TotalAmount { get; init; }
        public int UserId { get; init; }
        public User User { get; init; }
    }
}
