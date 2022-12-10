namespace MongoBackend.Models
{
    public class Users
    {

        public int? _id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public int? phone { get; set; }

        public string adress { get; set; }

        public DateTime dateIn { get; set; }
    }
}
