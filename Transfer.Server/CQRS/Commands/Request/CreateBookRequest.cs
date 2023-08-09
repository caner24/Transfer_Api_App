using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Commands.Request
{
    public class CreateBookRequest:IRequest<CreateBookResponse>
    {
        public int UserId { get; set; }
        public string VehicleId { get; set; }
    }
}
