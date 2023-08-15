using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client;
using Transfer.Client.Request;
using Transfer.Client.Response;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;
using Transfer.Server.Mapper;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetRoundWayQueryHandler : IRequestHandler<GetRoundWayRequest, List<GetRoundWayResponse>>
    { 
        private readonly ICacheManager _cacheManager;
        private readonly TransferClient _transferClient;
        public GetRoundWayQueryHandler( TransferClient transferClient, ICacheManager cacheManager)
        {
            _transferClient = transferClient;
            _cacheManager = cacheManager;
        }
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
