using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;

namespace Transfer.Server.CQRS.Commands.Response
{
    public class CreateBookTransferResponse
    {
        public string Pnr { get; set; }
        public object Contact { get; set; }
        public string BookingStatusType { get; set; }
        public object Transfers { get; set; }
    }
}
