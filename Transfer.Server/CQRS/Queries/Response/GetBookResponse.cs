using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Server.CQRS.Queries.Response
{
    public class GetBookResponse
    {
        public string Pnr { get; set; }
        public object Contact { get; set; }
        public string BookingStatusType { get; set; }
        public object Transfers { get; set; }
    }
}
