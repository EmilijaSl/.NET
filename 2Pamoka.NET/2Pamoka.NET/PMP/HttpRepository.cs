namespace _2Pamoka.NET.PMP

{
    public class HttpRepository : IHttpRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _accessKey;

        public HttpRepository(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _accessKey = config.GetSection("ApiKey").Value;
        }

        public async Task<string> GetAsync()
        {
            var item = _httpClientFactory.CreateClient("Client");
            item.DefaultRequestHeaders.Add("ApiKey", _accessKey);
            using var response = await item.GetAsync(
               $"/WeatherForecast/ApiKey");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> GetAsyncWeather()
        {
            throw new NotImplementedException();
        }
    }
}
