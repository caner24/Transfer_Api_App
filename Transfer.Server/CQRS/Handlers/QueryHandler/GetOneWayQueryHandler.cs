using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetOneWayQueryHandler : IRequestHandler<GetOneWayRequest, List<GetOneWayResponse>>
    {
        private readonly ICacheManager _cacheManager;
        public GetOneWayQueryHandler(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        HttpClient client = new HttpClient();
        public async Task<List<GetOneWayResponse>> Handle(GetOneWayRequest request, CancellationToken cancellationToken)
        {
            if (_cacheManager.IsAdd("GetOneWayResponse"))
            {
                return _cacheManager.Get<List<GetOneWayResponse>>("GetOneWayResponse");
            }

            var queryString = GetQueryStringFromRequest(request);
            var apiUrl = $"https://f311752a-e715-4445-be21-842206f699ec.mock.pstmn.io/transfer/search?{queryString}";
            var response = await client.GetFromJsonAsync<List<GetOneWayResponse>>(apiUrl, cancellationToken);
            _cacheManager.Add("GetOneWayResponse", response, 60);
            return _cacheManager.Get<List<GetOneWayResponse>>("GetOneWayResponse");
        }

        private string GetQueryStringFromRequest(GetOneWayRequest request)
        {
            var queryString = new StringBuilder();

            queryString.Append($"adults={request.Adults}&children={request.Children}");
            queryString.Append($"&pickUpPointLatitude={request.PickUpPointLatitude}&pickUpPointLongitude={request.PickUpPointLongitude}");
            queryString.Append($"&dropOffPointLatitude={request.DropOffPointLatitude}&dropOffPointLongitude={request.DropOffPointLongitude}");
            queryString.Append($"&date={request.Date:yyyy-MM-ddTHH:mm:ss}");
            queryString.Append($"&PageNumber={request.PageNumber}&PageSize={request.PageSize}&SortType={request.SortType}");

            return queryString.ToString();
        }
    }
}
