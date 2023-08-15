using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Client.Request
{
    public class TransferServiceSerachRoundWayRequest:TransferServiceSearchOneWayRequest
    {
        public DateTime ReturnDate { get; set; }
    }
}
