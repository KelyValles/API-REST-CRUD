using MongoDB.Driver;

namespace API.Services
{
    public class MongoDBRepository
    {
        //MongoClient = provider // nexo entre la DB y la aplicación
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://KelyAdmin:hpKxPSTwjKNCZ26X@cluster0.ett9rom.mongodb.net/");
            db = client.GetDatabase("api_cars");
        }

    }
}
