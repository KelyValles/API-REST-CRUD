using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await carCollection.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDetail(string id)
        {
            return Ok(await carCollection.GetCarById(id));
        }

        [HttpGet("{Category}/{Brand}")]
        public async Task<IActionResult> GetCarParameters(string Category, string Brand)
        {
            return Ok(await carCollection.GetCarParameters(Category, Brand));
        }



        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]Car car)
        {
            if (car == null)
             return BadRequest();
             
            if (car.Category == string.Empty)
            {
                ModelState.AddModelError("Category", "The field shouldn´t be empty");
            }

            await carCollection.InsertCar(car);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Car car, string id)
        {
            if (car == null)
                return BadRequest();

            if (car.Category == string.Empty)
            {
                ModelState.AddModelError("Category", "The car shouldn´t be empty");
            }

            car.Id = new MongoDB.Bson.ObjectId(id);
            await carCollection.UpdateCar(car);

            return Created("Updated", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            await carCollection.DeleteCar(id);
            return NoContent(); 
        }
        
    }
}
