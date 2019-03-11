using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDB
{
    class Program
    {
        protected static IMongoClient client;
        protected static IMongoDatabase database;

        static void Main(string[] args)
        {
            client = new MongoClient();
            database = client.GetDatabase("Clients");

            AddClient();

            Console.WriteLine("Users before changes:");
            PrintClients();

            UpdateClient();
            Console.WriteLine("Users after changes:");
            PrintClients();

            Console.ReadKey();
        }

        private static void AddClient()
        {
            var data = database.GetCollection<Client>("Client");

            data.InsertOne(new Client
            {
                FirstName = "FirstName1",
                LastName = "LastName2",
                Age = 20
            });
        }

        private static void UpdateClient()
        {
            var data = database.GetCollection<Client>("Client");

            data.FindOneAndUpdate<Client>
                (Builders<Client>.Filter.Eq("LastName", "LastName2"),
                Builders<Client>.Update.Set("LastName", "LastName1"));
        }

        private static void PrintClients()
        {
            var data = database.GetCollection<Client>("Client");

            var clients = data.Find(new BsonDocument());

            foreach (var client in clients.ToEnumerable())
            {
                Console.WriteLine($"Id: {client.Id}, FirstName: {client.FirstName}, LastName: {client.LastName}, Age: {client.Age}");
            }
        }
    }
}
