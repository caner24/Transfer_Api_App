using MediatR;
using Transfer.Client.Request;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Commands.Request
{
    public class CreateBookRequest : IRequest<CreateBookResponse>
    {
        public string VehicleId { get; init; }
        public int Adults { get; init; }
        public int Children { get; init; }
        public int UserId { get; init; }
        public List<Tag> Tags { get; init; }
    }
}
