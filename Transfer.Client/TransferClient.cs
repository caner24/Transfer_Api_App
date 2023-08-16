using System.Net.Http;
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
            _httpClient.BaseAddress = new Uri("https://f311752a-e715-4445-be21-842206f699ec.mock.pstmn.io");
        }

        public HttpClient GetTransferClient()
        {
            return _httpClient;
        }

        public async Task<List<TransferServiceSearchOneWayResponse>> SearchOneWay(TransferServiceSearchOneWayRequest transferServiceSearchOneWayRequest)
        {
            return await Get<List<TransferServiceSearchOneWayResponse>>(
                     $"transfer/search?adults={transferServiceSearchOneWayRequest.Adults}" +
                     $"&children={transferServiceSearchOneWayRequest.Children}&" +
                     $"pickUpPointLatitude={transferServiceSearchOneWayRequest.PickUpPointLatitude}" +
                     $"&pickUpPointLongitude={transferServiceSearchOneWayRequest.PickUpPointLongitude}&" +
                     $"dropOffPointLatitude={transferServiceSearchOneWayRequest.DropOffPointLatitude}" +
                     $"&dropOffPointLongitude={transferServiceSearchOneWayRequest.DropOffPointLongitude}" +
                     $"&date={transferServiceSearchOneWayRequest.Date}",
                     cancellationToken: CancellationToken.None
                     );
        }
        public async Task<List<TransferServiceSearchOneWayResponse>> SearchRoundWay(TransferServiceSerachRoundWayRequest transferServiceSearchRoundWayRequest)
        {
            return await Get<List<TransferServiceSearchOneWayResponse>>(
                   $"transfer/search?adults={transferServiceSearchRoundWayRequest.Adults}" +
                   $"&children={transferServiceSearchRoundWayRequest.Children}&" +
                   $"pickUpPointLatitude={transferServiceSearchRoundWayRequest.PickUpPointLatitude}" +
                   $"&pickUpPointLongitude={transferServiceSearchRoundWayRequest.PickUpPointLongitude}&" +
                   $"dropOffPointLatitude={transferServiceSearchRoundWayRequest.DropOffPointLatitude}" +
                   $"&dropOffPointLongitude={transferServiceSearchRoundWayRequest.DropOffPointLongitude}" +
                   $"&date={transferServiceSearchRoundWayRequest.Date}" +
                   $"&returnDate={transferServiceSearchRoundWayRequest.ReturnDate}",
                   cancellationToken: CancellationToken.None
                   );
        }
        public async Task<TransferServiceBookResponse> GetBook(TransferSerivceGetBookRequest transferSerivceGetBookRequest)
        {
            return await Get<TransferServiceBookResponse>(
                     $"transfers/reservations/{transferSerivceGetBookRequest.Pnr}?LastName={transferSerivceGetBookRequest.LastName}",
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