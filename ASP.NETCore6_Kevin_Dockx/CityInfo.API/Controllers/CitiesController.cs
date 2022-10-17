using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase //turi basic functionalities kontorleriui. 
    {

        [HttpGet/*("api/cities")*/] //sitas pavadinimas kabutese atsispindi prie swagerio metodo
        //jsonresult - grazino jsno'izuota versija to ka paduosime. 
        //action result grazina su status kodais, kurie naudingi zinoti apie klaidos pobudi 

        public ActionResult<IEnumerable<CityDto>> GetCities() //IEnumerable grazina sarasa kurio template yra citydto
        { 
    
            return Ok(CitiesDataStore.Current.Cities);
        }
        [HttpGet("{id}")] //api cities bus nurodyta is auksciau cia naudojame tai ka iterpiame
        public ActionResult<CityDto> GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }
    }

}
