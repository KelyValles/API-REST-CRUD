using API.Models;

namespace API.Services
{
    public interface ICategoriesCollection
    {
        Task CreateCategories(Categories categories);
        Task UpdateCategories(Categories categories);
        Task DeleteCategories(string id);
        Task<List<Categories>> GetAllCategories();
        Task<Categories> GetCategoriesById(string id);
        Task<bool> Exists(string id);
    }
}
