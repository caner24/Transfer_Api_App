namespace Transfer.Client.Tests
{
    public class Tests
    {
        private HttpClient _httpClient;
        private TransferClient _apiService;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _apiService = new TransferClient(_httpClient);
        }

        [TearDown]
        public void Cleanup()
        {
            _httpClient.Dispose();
            _apiService = null;
        }

        [Test]
        public async Task GetTransferData_ValidRequest_ReturnsData()
        {
            var result =  _apiService.GetTransferClient().GetAsync("/DEMOPNR?LastName=DEMOTEST");
            Assert.IsNotNull(result);
        }
    }
}