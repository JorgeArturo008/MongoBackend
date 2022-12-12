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



        public void InsertUser(Users users)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://Root:multicaribe1@cluster0.owjr3hy.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var user = db.GetCollection<BsonDocument>("Users");

            var doc = new BsonDocument
        {

            {"name", users.name },
            {"email", users.email },
            {"phone", users.phone },
            {"adress", users.adress },
            {"dateIn", users.dateIn}


        };

            user.InsertOne(doc);
        }
    }
}
