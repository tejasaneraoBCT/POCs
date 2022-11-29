using InMemoryDbDemo.Entities;
using InMemoryDbDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryDbDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepo _cityRepo;
        public CityController(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCitiesAsync()
        {
            return Ok(await _cityRepo.GetCitiesAsync());
        }

        [HttpGet("{id}", Name = "GetCityById")]
        public async Task<ActionResult<City>> GetCityByIdAsync([FromRoute] int id)
        {
            var city = await _cityRepo.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpGet("PointOfInterest")]
        public async Task<ActionResult<IEnumerable<PointOfInterest>>> GetPointsOfInterestAsync()
        {
            return Ok(await _cityRepo.GetPointsOfInterestAsync());
        }


        [HttpPost]
        public async Task<ActionResult<City>> AddCityAsync(City city)
        {
            var newCity = await _cityRepo.AddCityAsync(city);
            return CreatedAtRoute("GetCityById", new { id = city.Id }, city);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCityAsync([FromRoute] int id)
        {
            var cityExists = await _cityRepo.GetCityByIdAsync(id);
            if(cityExists == null)
            {
                return NotFound("City Not Found");
            }
            var result = await _cityRepo.DeleteCityAsync(id);
            return NoContent();
        }
    }
}