using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.Response;
using Transfer.Client.ResponseAlt;

namespace Transfer.Server.CQRS.Queries.Request
{
    public class GetBookRequest:IRequest<Root>
    {
        public string Pnr { get; set; }
        public int UserId { get; set; }
    }
}
