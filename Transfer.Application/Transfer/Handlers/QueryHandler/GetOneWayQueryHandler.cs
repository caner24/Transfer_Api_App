using MediatR;
using PostSharp.Patterns.Caching;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Client;
using Transfer.Client.Request;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Core.CrosCuttingConcerns.Caching.Microsoft;
using Transfer.Core.CrosCuttingConcerns.Logging.Serilog;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.Mapping.AutoMapper;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{

    [CacheConfiguration(ProfileName = "GetOneWayResponse")]
    public class GetOneWayQueryHandler : IRequestHandler<GetOneWayRequest, List<GetOneWayResponse>>
    {
        private readonly ICacheManager _cacheManager;
        private readonly TransferClient _transferClient;
        public GetOneWayQueryHandler(TransferClient transferClient, ICacheManager cacheManager)
        {
            _transferClient = transferClient;
            _cacheManager = cacheManager;
        }

        [Cache]
        public async Task<List<GetOneWayResponse>> Handle(GetOneWayRequest request, CancellationToken cancellationToken)
        {
            var mapper = MapperConfig.ConfigureMappings();
            TransferServiceSearchOneWayRequest transferServiceSearchOneWayRequest = new TransferServiceSearchOneWayRequest()
            {
                Adults = request.Adults,
                Children = request.Children,
                Date = request.Date,
                DropOffPointLatitude = request.DropOffPointLatitude,
                DropOffPointLongitude = request.DropOffPointLongitude,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                PickUpPointLatitude = request.PickUpPointLatitude,
                PickUpPointLongitude = request.PickUpPointLongitude,
                SortType = request.SortType
            };
            var oneWayResponse = await _transferClient.SearchOneWay(transferServiceSearchOneWayRequest);
            List<GetOneWayResponse> response = oneWayResponse.Select(item => mapper.Map<GetOneWayResponse>(item)).ToList();
            return response;
        }
    }
}
