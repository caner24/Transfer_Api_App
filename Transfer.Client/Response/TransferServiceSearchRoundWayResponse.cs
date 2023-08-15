using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Client.Response
{
    public class TransferServiceSearchRoundWayResponse:TransferServiceSearchOneWayResponse
    {
        public DateTime ReturnDate { get; set; }
    }
}
