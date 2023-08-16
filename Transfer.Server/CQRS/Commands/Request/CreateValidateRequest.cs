using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Transfer.Client.Request;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Commands.Request
{
    public class CreateValidateRequest : IRequest<CreateValidateResponse>
    {
        public string VehicleId { get; init; }
        public int Adults { get; init; }
        public int Children { get; init; }
        public int UserId { get; init; }
        public List<Tag> Tags { get; init; }
    }
}
