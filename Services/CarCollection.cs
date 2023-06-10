using API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services
{
    public class CarCollection : ICarCollection
    {


        private IMongoCollection<Car> Collection;
        public CarCollection(ISettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            Collection = database.GetCollection<Car>(settings.Collection.Car);
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

        public async Task<List<Car>> GetCarParameters(string category, string brand)
        {
            var filter = Builders<Car>.Filter.And(
                Builders<Car>.Filter.Eq("Category", category),
                Builders<Car>.Filter.Eq("Brand", brand)
            );

            var cars = await Collection.Find(filter).ToListAsync();

            return cars;

        }

        public async Task CreateCar(Car car)
        {
            await Collection.InsertOneAsync(car);
        }

        public async Task UpdateCar(Car car)
        {
            var filter = Builders<Car>.Filter.Eq(s => s.Id, car.Id);
            await Collection.ReplaceOneAsync(filter, car);
        }

        public async Task<bool> Exists(string id)
        {
            var filter = Builders<Car>.Filter.Eq(s => s.Id, new ObjectId(id));
            var count = await Collection.CountDocumentsAsync(filter);
            return count > 0;
        }
    }
}
