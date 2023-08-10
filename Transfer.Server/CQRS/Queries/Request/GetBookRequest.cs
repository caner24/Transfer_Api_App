using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Queries.Request
{
    public class GetBookRequest:IRequest<GetBookResponse>
    {
        public string Pnr { get; set; }
        public int UserId { get; set; }
    }
}
