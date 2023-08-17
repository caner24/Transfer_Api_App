using System.Net.Http;
using Transfer.Client.Extensions;
using Transfer.Client.Request;
using Transfer.Client.Response;
using Transfer.Client.ResponseAlt;

namespace Transfer.Client
{
    public class TransferClient : HttpBaseMethods
    {
        private readonly HttpClient _httpClient;

        public TransferClient(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }
        public HttpClient GetTransferClient()
        {
            return _httpClient;
        }

        public async Task<List<TransferServiceSearchOneWayResponse>> SearchOneWay(TransferServiceSearchOneWayRequest transferServiceSearchOneWayRequest)
        {
            return await Get<List<TransferServiceSearchOneWayResponse>>(TransferServiceRequestQueryStringExtensions.TransferServiceOneWayRequesttQueryString(transferServiceSearchOneWayRequest),
                     cancellationToken: CancellationToken.None
                     );
        }
        public async Task<List<TransferServiceSearchRoundWayResponse>> SearchRoundWay(TransferServiceSerachRoundWayRequest transferServiceSearchRoundWayRequest)
        {
            return await Get<List<TransferServiceSearchRoundWayResponse>>(TransferServiceRequestQueryStringExtensions.TransferServiceOneWayRequesttQueryString(transferServiceSearchRoundWayRequest),
                   cancellationToken: CancellationToken.None
                   );
        }
        public async Task<TransferServiceBookResponse> GetBook(TransferSerivceGetBookRequest transferSerivceGetBookRequest)
        {
            return await Get<TransferServiceBookResponse>(
                TransferServiceRequestQueryStringExtensions.TransferServiceGetBookRequestQueryString(transferSerivceGetBookRequest),
                     cancellationToken: CancellationToken.None
                     );
        }
        public async Task<TransferServiceBookResponse> CreateBook(TransferServiceCreateBookRequest transferServiceCreateBookRequest)
        {
            return await Post<TransferServiceBookResponse>("/transfer/book", transferServiceCreateBookRequest, cancellationToken: CancellationToken.None);
        }

        public async Task<TransferServiceBookResponse> Validate(TransferServiceBookValidateRequest transferServiceValidateRequest)
        {
            return await Post<TransferServiceBookResponse>("/transfer/validate", transferServiceValidateRequest, cancellationToken: CancellationToken.None);
        }
    }
}