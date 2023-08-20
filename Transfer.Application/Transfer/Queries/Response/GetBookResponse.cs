using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.ResponseAlt;

namespace Transfer.Application.Campaign.Queries.Response
{
    public  class GetBookResponse
    {
        public string Pnr { get; set; }
        public Contact Contact { get; set; }
        public string BookingStatusType { get; set; }
        public Transfers Transfers { get; set; }
    }
}
