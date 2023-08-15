using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client;
using Transfer.Client.Response;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetOneWayQueryHandler : IRequestHandler<GetOneWayRequest, List<TransferServiceSearchResponse>>
    {
        private readonly ICacheManager _cacheManager;
        private readonly TransferClient _transferClient;
        public GetOneWayQueryHandler(TransferClient transferClient,ICacheManager cacheManager)
        {
            _transferClient = transferClient;
            _cacheManager = cacheManager;
        }
        public async Task<List<TransferServiceSearchResponse>> Handle(GetOneWayRequest request, CancellationToken cancellationToken)
        {
            if (_cacheManager.IsAdd("GetOneWayResponse"))
            {
                return _cacheManager.Get<List<TransferServiceSearchResponse>>("GetOneWayResponse");
            }
            var response = await _transferClient.SearchOneWay();
            _cacheManager.Add("GetOneWayResponse", response, 60);
            return _cacheManager.Get<List<TransferServiceSearchResponse>>("GetOneWayResponse");
        }

     
    }
}
