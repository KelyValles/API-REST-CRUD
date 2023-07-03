using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        ICarCollection carCollection;
        
        public CarController(ICarCollection carcollection)
        {
            carCollection = carcollection;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await carCollection.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(string id)
        {
            bool exists = await carCollection.Exists(id);
            if (!exists)
            {
                return NotFound("ID doesn't exist in the database");
            }

            return Ok(await carCollection.GetCarById(id));
        }

        [HttpGet("{Category}/{Brand}")]
        public async Task<IActionResult> GetCarParameters(string Category, string Brand)
        {
            return Ok(await carCollection.GetCarParameters(Category, Brand));
        }



        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            await carCollection.CreateCar(car);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar([FromBody] Car car, string id)
        {
            bool exists = await carCollection.Exists(id);
            if (!exists)
            {
                return NotFound("ID doesn't exist in the database");
            }

            car.Id = new MongoDB.Bson.ObjectId(id);
            await carCollection.UpdateCar(car);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            bool exists = await carCollection.Exists(id);
            if (!exists)
            {
                return NotFound("ID doesn't exist in the database");
            }

            await carCollection.DeleteCar(id);
            return NoContent();
        }

    }
}
