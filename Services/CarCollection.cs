using API.Models;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services
{
    public class CarCollection : ICarCollection
    {
        //agregar repositorio,acceder a la db
        internal MongoDBRepository _repository = new MongoDBRepository();


        //add collection 
        private IMongoCollection<Car> Collection;

        public CarCollection()
        {
            Collection = _repository.db.GetCollection<Car>("car");
        }

        public async Task DeleteCar(string id)
        {
            var filter = Builders<Car>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);

        }

        public async Task<List<Car>> GetAllCars()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Car> GetCarById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<Car> GetCarParameters(string id, string category)
        {
            var filter = Builders<Car>.Filter.Eq("_id", new ObjectId(id));
            var car = await Collection.FindAsync(filter).Result.FirstAsync();

            if (car != null)
            {
                car.Category = category;
            }

            return car;
        }

        public async Task InsertCar(Car car)
        {
            await Collection.InsertOneAsync(car);
        }

        public async Task UpdateCar(Car car)
        {
            var filter = Builders<Car>.Filter.Eq(s => s.Id, car.Id);
            await Collection.ReplaceOneAsync(filter, car);  
        }
    }
}
