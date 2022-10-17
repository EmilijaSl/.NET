using Domain;
using Infrastucture.HttpLayer;
using Infrastyructure.DbLayer;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherHttpRepository _httpRepository;
        private readonly IWeatherDbRepository _dbRepository;
        private readonly ILogger<WeatherService> _logger;
        public WeatherService(IWeatherHttpRepository httpRepository, IWeatherDbRepository dbRepository, ILogger<WeatherService> logger)
        {
            _httpRepository = httpRepository;
            _dbRepository = dbRepository;
            _logger = logger;
        }
        public async Task<Weather> ReadAndSaveWeatherDataAsync(string city)
        {
            _logger.LogDebug($"Getting weather data from city {city}");
            var weather = await _httpRepository.GetWeatherDataAsync(city);
            _logger.LogDebug($"Received weather data from API: {JsonConvert.SerializeObject(weather)}");
            await _dbRepository.InsertAsync(weather);
            return weather;
        }
    }
}
