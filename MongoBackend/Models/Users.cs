
using MongoDB.Bson;

namespace MongoBackend.Models
{
    public class Users
    {

        public ObjectId? _id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public Int32? phone { get; set; }

        public string adress { get; set; }

        public DateTime dateIn { get; set; }
    }
}
