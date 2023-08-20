using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.Request;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Application.Transfer.Commands.Request.DataTransferObjects
{
    public record class CreateBookRequestDto : IRequest<CreateBookResponse>
    {
        public string? VehicleId { get; init; }
        public int? Adults { get; init; }
        public int? Children { get; init; }
        public int? UserId { get; init; }
        public List<Tag>? Tags { get; init; }
    }
}
