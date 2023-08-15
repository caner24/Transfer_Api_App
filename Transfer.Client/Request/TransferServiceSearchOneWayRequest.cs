using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Client.Request
{
    public class TransferServiceSearchOneWayRequest
    {
        public int Adults { get; set; }
        public int Children { get; set; }
        public double PickUpPointLatitude { get; set; }
        public double PickUpPointLongitude { get; set; }
        public double DropOffPointLatitude { get; set; }
        public double DropOffPointLongitude { get; set; }
        public DateTime Date { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortType { get; set; }
    }
}
