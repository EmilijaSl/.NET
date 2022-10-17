using Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WeatherBackend;

namespace Infrastucture.HttpLayer
{
    public class WeatherHttpRepository : IWeatherHttpRepository
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _accessKey;


        public WeatherHttpRepository(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _accessKey = config.GetSection("WeatherApiAccessKey").Value; //sita dalis kurios pratesimas json atsaking kad access key nusiskaitytume is ten 
        }

        public async Task<Weather> GetWeatherDataAsync(string city)
        {
            var client = _httpClientFactory.CreateClient("WeatherClient");
            using var response = await client.GetAsync(
                $"/current?access_key={_accessKey}&query={HttpUtility.UrlEncode(city)}");

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var bodyAsObject = JsonConvert.DeserializeObject<WeatherDataDto>(body); //<> viduje rasone i koki tipa pakeisti jsona

            return new Weather
            {
                Country = bodyAsObject.location.country,
                Language = bodyAsObject.request.language,
                Region = bodyAsObject.location.region,
                Temperature = bodyAsObject.current.temperature
            };
        }
    }
}
