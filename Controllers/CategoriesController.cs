using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoriesCollection categoriesCollection;

        public CategoriesController(ICategoriesCollection categoriescollection)
        {
            categoriesCollection = categoriescollection;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await categoriesCollection.GetAllCategories());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesById(string id)
        {
            bool exists = await categoriesCollection.Exists(id);
            if (!exists)
            {
                return NotFound("ID doesn't exist in the database");
            }

            return Ok(await categoriesCollection.GetCategoriesById(id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategories([FromBody] Categories categories)
        {
            await categoriesCollection.CreateCategories(categories);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategories([FromBody] Categories categories, string id)
        {
            bool exists = await categoriesCollection.Exists(id);
            if (!exists)
            {
                return NotFound("ID doesn't exist in the database");
            }

            categories.Id = new MongoDB.Bson.ObjectId(id);
            await categoriesCollection.UpdateCategories(categories);

            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            bool exists = await categoriesCollection.Exists(id);
            if (!exists)
            {
                return NotFound("ID doesn't exist in the database");
            }

            await categoriesCollection.DeleteCategories(id);
            return NoContent();
        }

        
    }
}
