using MediatR;
using PostSharp.Patterns.Caching;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Client;
using Transfer.Client.Request;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.Mapping.AutoMapper;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    [CacheConfiguration(ProfileName = "GetRoundWayResponse")]
    public class GetRoundWayQueryHandler : IRequestHandler<GetRoundWayRequest, List<GetRoundWayResponse>>
    { 
        private readonly ICacheManager _cacheManager;
        private readonly TransferClient _transferClient;
        public GetRoundWayQueryHandler( TransferClient transferClient, ICacheManager cacheManager)
        {
            _transferClient = transferClient;
            _cacheManager = cacheManager;
        }
        [Cache]
        public async Task<List<GetRoundWayResponse>> Handle(GetRoundWayRequest request, CancellationToken cancellationToken)
        {
            var mapper = MapperConfig.ConfigureMappings();
            if (_cacheManager.IsAdd("GetRoundWayResponse"))
            {
                return _cacheManager.Get<List<GetRoundWayResponse>>("GetRoundWayResponse");
            }
     
            var httpRequest = mapper.Map<TransferServiceSerachRoundWayRequest>(request);
            var roundWayResponse = await _transferClient.SearchRoundWay(httpRequest);
            List<GetRoundWayResponse> response = roundWayResponse.Select(item => mapper.Map<GetRoundWayResponse>(item)).ToList();
            _cacheManager.Add("GetRoundWayResponse", response, 60);
            return _cacheManager.Get<List<GetRoundWayResponse>>("GetRoundWayResponse");
        }
    }
}
