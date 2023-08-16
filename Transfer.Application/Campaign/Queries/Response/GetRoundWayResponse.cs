using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Application.Campaign.Queries.Response
{
    public  class GetRoundWayResponse : GetOneWayResponse
    {
        public DateTime ReturnDate { get; set; }
    }
}
