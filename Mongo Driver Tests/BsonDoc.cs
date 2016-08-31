using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_tests
{
    class test1
    {
/*
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
*/
        static async Task MainAsync(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("BadgeScanner");
            var col = db.GetCollection<BsonDocument>("Employees");

            var doc = new BsonDocument
            {
                {"name", "Victor"}
            };
            doc.Add("badge", 234243);
            doc.Add("access", "Admin");
            Console.WriteLine(doc);
        }
    }
}
