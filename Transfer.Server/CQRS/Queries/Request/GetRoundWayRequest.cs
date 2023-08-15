using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Queries.Request
{
    public class GetRoundWayRequest : IRequest<List<GetRoundWayResponse>>
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
        public DateTime ReturnDate { get; init; }
    }
}
