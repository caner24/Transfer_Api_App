using System.Net.Http;

namespace Transfer.Client
{
    public class TransferClient
    {
        private readonly HttpClient _httpClient;

        public TransferClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://f311752a-e715-4445-be21-842206f699ec.mock.pstmn.io");
        }

        public HttpClient GetTransferClient()
        {
            return _httpClient;
        }
    }
}