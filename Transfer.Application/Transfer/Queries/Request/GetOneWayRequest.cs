using MediatR;
using Transfer.Application.Campaign.Queries.Response;


namespace Transfer.Server.CQRS.Queries.Request
{
    public class GetOneWayRequest : IRequest<List<GetOneWayResponse>>
    {
        public int Adults { get; init; }
        public int Children { get; init; }
        public double PickUpPointLatitude { get; init; }
        public double PickUpPointLongitude { get; init; }
        public double DropOffPointLatitude { get; init; }
        public double DropOffPointLongitude { get; init; }
        public DateTime Date { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public string SortType { get; init; }
    }
}
