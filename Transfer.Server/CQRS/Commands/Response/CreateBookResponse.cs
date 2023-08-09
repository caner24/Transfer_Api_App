using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Server.Models;

namespace Transfer.Server.CQRS.Commands.Response
{
    public class CreateBookResponse
    {
        public string Pnr { get; set; }
        public bool BookingStatusType { get; set; }
    }
}
