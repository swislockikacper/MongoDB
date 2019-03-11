using MongoDB.Bson;

namespace MongoDB
{
    public class Client
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
    }
}
