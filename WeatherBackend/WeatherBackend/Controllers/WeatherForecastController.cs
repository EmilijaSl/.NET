using BusinessLogic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace WeatherBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet(Name = "GetWeatherForecast")]

        public async Task<ActionResult<Weather>> Get([FromQuery] string? city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest("City cant be null");
            }
            Weather weather;
            try
            {
                weather = await _service.ReadAndSaveWeatherDataAsync(city);
            }
            catch (NullReferenceException)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            _logger.LogInformation($"Returning weather data in city {city}:{JsonConvert.SerializeObject(weather)}");
            return Ok(weather);








} } }
        

     


