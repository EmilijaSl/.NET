using _2Pamoka.NET.PMP;
using BusinessLogic;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace _2Pamoka.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CarControler : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ILogger<CarControler> _logger;
        private readonly IHttpRepository _httpRepository;
        public CarControler(ICarService carService, ILogger<CarControler> logger, IHttpRepository httpRepository)
        {
            _carService = carService;
            _logger = logger;
            _httpRepository = httpRepository;
        }

        [HttpGet("task")]
        public async Task<string> ReturnText()
        {

            return await _httpRepository.GetAsync();
        }

        [HttpGet ("allCars")]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var allCars = _carService.GetAllCars();
            return Ok(allCars);
        }
        [HttpGet("byColor")]
        public ActionResult<IEnumerable<Car>> GetAllCarsByColor([FromQuery] string color)
        {
            var sameColorCars = _carService.GetCarsByColor(color);
            return Ok(sameColorCars);
        }
        [HttpPost]
        public object CreateCar([FromBody] CarDTO car)
        {
            _logger.LogInformation("api/Accounts [POST] action was called");
            var freshCar = _carService.CreateCar(new Car()
            {
                CarModel = car.CarModel,
                CarColor = car.CarColor,
            });
            _logger.LogInformation("Account was created");
            dynamic returnValue = new { Id = freshCar };
            return returnValue;
            
            }

            [HttpDelete]
            public object DeleteCar(int id)
            {
                _carService.DeleteCar(id);
                return Ok();
            }

            [HttpPut]
            public IActionResult UpdateCar(CarDTO carDTO, [FromQuery] int id)
            {
                var updatedCar = new Car()
                {
                    Id = id,
                    CarModel = carDTO.CarModel,
                    CarColor = carDTO.CarColor
                };
                _carService.UpdateCar(updatedCar);
                return Ok(updatedCar);

            }

        }
    } 
