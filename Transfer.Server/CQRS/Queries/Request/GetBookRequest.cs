using MediatR;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Queries.Request
{
    public class GetBookRequest:IRequest<GetBookResponse>
    {
        public string? Pnr { get; init; }
        public string? LastName { get; init; }
    }
}
