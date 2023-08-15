using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.ResponseAlt;

namespace Transfer.Server.CQRS.Queries.Response
{
    public class GetBookResponse
    {
        public string Pnr { get; init; }
        public Contact Contact { get; init; }
        public string BookingStatusType { get; init; }
        public Transfers Transfers { get; init; }
    }
}
