using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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
            var cars = await carCollection.GetAllCars();

            var carsWithUniqueId = cars.Select(car => new
            {
                Id = GetObjectIdAsString(car.Id),
                car.Category,
                car.Brand,
                car.Model,
                car.Color,
                car.EngineType
            });

            return Ok(carsWithUniqueId);
        }

        private string GetObjectIdAsString(object id)
        {
            if (id is ObjectId objectId)
            {
                return objectId.ToString();
            }

            return string.Empty; // O cualquier valor por defecto que desees
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
