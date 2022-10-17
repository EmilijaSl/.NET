using System.Web;

namespace Attempt
{
    public class HttpRepository : IHttpRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _accessKey;

        public HttpRepository(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _accessKey = config.GetSection("ApiKey").Value; //sita dalis kurios pratesimas json atsaking kad access key nusiskaitytume is ten 
        }

        public async Task<string> GetAsync()
        {
            var item = _httpClientFactory.CreateClient("Client");
            item.DefaultRequestHeaders.Add("ApiKey", _accessKey); //musu klientas prie kurio reuesto headerio pridedam dar viena , kuriio reiksme acces key kuri paeme is json
            using var response = await item.GetAsync(
                $"/WeatherForecast/ApiKey");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();  //sitas metodas grazins teksta is kontrolerio
        }


        public async Task<string> GetAsyncAllCars()
        {
            var item = _httpClientFactory.CreateClient("Client7");
            item.DefaultRequestHeaders.Add("allCars", _accessKey); //musu klientas prie kurio reuesto headerio pridedam dar viena , kuriio reiksme acces key kuri paeme is json
            using var response = await item.GetAsync(
                $"/api/CarControler/allCars");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();  //sitas metodas grazins teksta is kontrolerio
        }



        public async Task<string> GetAsyncWeather()
        {
            var item = _httpClientFactory.CreateClient("Client");
            item.DefaultRequestHeaders.Add("GetWeatherForecast", _accessKey); //musu klientas prie kurio reuesto headerio pridedam dar viena , kuriio reiksme acces key kuri paeme is json
            using var response = await item.GetAsync(
                $"/WeatherForecast/GetWeatherForecast");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();  //sitas metodas grazins teksta is kontrolerio
        }
    }
}
