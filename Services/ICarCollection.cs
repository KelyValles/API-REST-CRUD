using API.Models;

namespace API.Services
{
    public interface ICarCollection
    {
        Task InsertCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(string id);
        Task<List<Car>> GetAllCars();
        Task<Car> GetCarById(string id);


    }
}
