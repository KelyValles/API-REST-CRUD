using API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services
{
    public class CategoriesCollection : ICategoriesCollection
    {
        private IMongoCollection<Categories> Collection;

        public CategoriesCollection(ISettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            Collection = database.GetCollection<Categories>(settings.Collection.Categories);
        }

        public async Task DeleteCategories(string id)
        {
            var filter = Builders<Categories>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Categories> GetCategoriesById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        

        public async Task CreateCategories(Categories categories)
        {
            await Collection.InsertOneAsync(categories);
        }

        public async Task UpdateCategories(Categories categories)
        {
            var filter = Builders<Categories>.Filter.Eq(s => s.Id, categories.Id);
            await Collection.ReplaceOneAsync(filter, categories);
        }

        public async Task<bool> Exists(string id)
        {
            var filter = Builders<Categories>.Filter.Eq(s => s.Id, new ObjectId(id));
            var count = await Collection.CountDocumentsAsync(filter);
            return count > 0;
        }
    }
}
