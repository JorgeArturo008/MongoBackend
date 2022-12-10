using MongoBackend.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MongoBackend.DatabaseHelper
{
    public class DataBase
    {
        public List<Users> GetUsers()
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://Root:multicaribe1@cluster0.owjr3hy.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var users = db.GetCollection<BsonDocument>("Users");

            List<BsonDocument> userArray = users.Find(new BsonDocument()).ToList();

            List<Users> userList = new List<Users>();

            foreach (BsonDocument bsonuser in userArray)
            {
                Users user = BsonSerializer.Deserialize<Users>(bsonuser);
                 userList.Add(user);

            }

                return userList;
        }

    }
}
