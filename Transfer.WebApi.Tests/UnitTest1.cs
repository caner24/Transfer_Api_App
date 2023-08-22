using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Transfer.Client;
using Transfer.Client.Request;
using Transfer.Client.Response;

namespace Transfer.WebApi.Tests
{
    public class UnitTest1 :IDisposable
    {
        public const int _expectedMaxElapsedMilliseconds = 1000;
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://f311752a-e715-4445-be21-842206f699ec.mock.pstmn.io")
        };

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        [Fact]
        public async void GivenARequest_WhenCallingGetOneWay_ThenTheAPIReturnsExpectedResponseSearchOneWay()
        {
            // Arrange
            var stopwatch = Stopwatch.StartNew();

            var expectedContent = new[]
            {

                 new{ProviderId="daadc3d9-4fe9-4cdd-aefb-60089aece1d2" } ,
                  new{ ProviderId="daadc3d9-4fe9-4cdd-aefb-60089aece1d2" }
            };
            // Act.
            var response = await _httpClient.GetFromJsonAsync<List<TransferServiceSearchOneWayResponse>>("/transfer/search?adults=1&children=0&pickUpPointLatitude=41.0370014&pickUpPointLongitude=28.9763369&dropOffPointLatitude=41.2567349&dropOffPointLongitude=28.740408&date=2023-08-17T17:35:21&PageNumber=1&PageSize=3&SortType=ByDateAsc");
            stopwatch.Stop();
            // Assert.
            Assert.Equal(response.First().ProviderId, expectedContent.First().ProviderId);
            Assert.Equal(response.Last().ProviderId, expectedContent.Last().ProviderId);
            Assert.True(_expectedMaxElapsedMilliseconds < stopwatch.ElapsedMilliseconds);
        }
    }
}