using MediatR;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Application.Campaign.Queries.Response.DataTransferObjects;
using Transfer.Client;
using Transfer.Client.Request;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.Mapping.AutoMapper;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetOneWayQueryHandler : IRequestHandler<GetOneWayRequest, List<GetOneWayResponse>>
    {
        private readonly ICacheManager _cacheManager;
        private readonly TransferClient _transferClient;
        public GetOneWayQueryHandler(TransferClient transferClient, ICacheManager cacheManager)
        {
            _transferClient = transferClient;
            _cacheManager = cacheManager;
        }
        public async Task<List<GetOneWayResponse>> Handle(GetOneWayRequest request, CancellationToken cancellationToken)
        {
            var mapper = MapperConfig.ConfigureMappings();
            if (_cacheManager.IsAdd("GetOneWayResponse"))
            {
                return _cacheManager.Get<List<GetOneWayResponse>>("GetOneWayResponse");
            }
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
            _cacheManager.Add("GetOneWayResponse", response, 60);
            return _cacheManager.Get<List<GetOneWayResponse>>("GetOneWayResponse");
        }
    }
}
