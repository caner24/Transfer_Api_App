using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.Response;

namespace Transfer.Application.Campaign.Queries.Response
{
    public  class GetOneWayResponse
    {
        public string Id { get; set; }
        public string ProviderId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string MaxBaggage { get; set; }
        public string MaxPassenger { get; set; }
        public double TotalPrice { get; set; }
        public string TransferType { get; set; }
        public Point PickUpPoint { get; set; }
        public Point DropOffPoint { get; set; }
        public string Date { get; set; }
        public GenericData GenericData { get; set; }
        public List<ExtraService> ExtraServices { get; set; }
    }
}
