using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Commands.Request
{
    public class CreateBookTransferRequest : IRequest<CreateBookTransferResponse>
    {
        public string VehicleIds { get; set; }
        public int UserId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }

    }
}
