using MediatR;
using Transfer.Client.Request;
using Transfer.Entity.DataTransferObjects.Stripe;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Commands.Request
{
    public class CreateBookRequest
    {
        public string VehicleId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int UserId { get; set; }
        public List<Tag> Tags { get; set; }


    }
}
