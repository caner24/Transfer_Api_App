using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.Response;

namespace Transfer.Application.Campaign.Queries.Response.DataTransferObjects
{
    public record class GetOneWayResponseDto
    {
        public string Id { get; init; }
        public string ProviderId { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public string MaxBaggage { get; init; }
        public string MaxPassenger { get; init; }
        public double TotalPrice { get; init; }
        public string TransferType { get; init; }
        public Point PickUpPoint { get; init; }
        public Point DropOffPoint { get; init; }
        public string Date { get; init; }
        public GenericData GenericData { get; init; }
        public List<ExtraService> ExtraServices { get; init; }
    }
}
