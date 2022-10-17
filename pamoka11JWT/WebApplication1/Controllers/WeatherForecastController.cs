using Attempt;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase

    {
        private readonly IHttpRepository _httpRepository;
        public WeatherForecastController(IHttpRepository httpRepository)
        { 
        _httpRepository = httpRepository;
        }

        [HttpGet("task")]
        public async Task <string> ReturnText()
        {

            return await _httpRepository.GetAsync();
        }
        [HttpGet("HomeAtempt")]
        public async Task<string> ReturnWeather()
        { 
        
        return await _httpRepository.GetAsyncWeather();
        }

        [HttpGet("HomeCars")]
        public async Task<String> ReturnCars()
        {
            return await _httpRepository.GetAsyncAllCars();
        }

    }
}