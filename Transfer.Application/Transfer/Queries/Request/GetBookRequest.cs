using MediatR;
using Transfer.Application.Campaign.Queries.Response;

namespace Transfer.Server.CQRS.Queries.Request
{
    public class GetBookRequest:IRequest<GetBookResponse>
    {
        public string? Pnr { get; init; }
        public string? LastName { get; init; }
    }
}
