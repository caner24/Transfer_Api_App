using System.Net.Http;
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
            _httpClient.BaseAddress = new Uri("https://f311752a-e715-4445-be21-842206f699ec.mock.pstmn.io");
        }

        public HttpClient GetTransferClient()
        {
            return _httpClient;
        }

        public async Task<List<TransferServiceSearchResponse>> SearchOneWay()
        {
            return await Get<List<TransferServiceSearchResponse>>(
                     "transfer/search?adults=1&children=0&pickUpPointLatitude=41.0370014&pickUpPointLongitude=28.9763369&dropOffPointLatitude=41.2567349&dropOffPointLongitude=28.740408&date=2023-06-17T17:35:21",
                     cancellationToken: CancellationToken.None
                     );
        }

        public async Task<List<TransferServiceSearchResponse>> SearchRoundWay()
        {
            return await Get<List<TransferServiceSearchResponse>>(
                     "transfer/search?adults=1&children=0&pickUpPointLatitude=41.0370014&pickUpPointLongitude=28.9763369&dropOffPointLatitude=41.2567349&dropOffPointLongitude=28.740408&date=2023-06-17T17:35:21",
                     cancellationToken: CancellationToken.None
                     );
        }

        public async Task<Root> GetBook(string pnr,string lastName)
        {
            return await Get<Root>(
                     $"transfers/reservations/{pnr}?LastName={lastName}",
                     cancellationToken: CancellationToken.None
                     );
        }
    }
}