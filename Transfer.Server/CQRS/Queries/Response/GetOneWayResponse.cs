using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Server.CQRS.Queries.Response
{
    public class GetOneWayResponse
    {
        public string Id { get; set; }
        public string ProviderId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string MaxBaggage { get; set; }
        public string MaxPassenger { get; set; }
        public double TotalPrice { get; set; }
        public string TransferPoint { get; set; }
        public object PickUpPoint { get; set; }
        public object DropOffPoint { get; set; }
        public DateTime Date { get; set; }
        public object GenericData { get; set; }
    }
}
