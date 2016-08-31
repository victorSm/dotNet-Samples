using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace MongoDB_tests
{
    class FindwithFilters
    {
 /*       static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
 */       
        static async Task MainAsync(string[] args)
        {
            var connString = "mongodb://localhost:27017";
            var client = new MongoClient(connString);
            var db = client.GetDatabase("test");
            var col = db.GetCollection<BsonDocument>("Employees");

            //var filter = new BsonDocument("name", "Smolinski");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Lt("badge", 600000 ) /*& !builder.Eq("name","Smolinski")*/;

            var list = await col.Find(filter/*new BsonDocument()*/).Project(Builders<BsonDocument>.Projection.Include("name").Include("badge")
                .Include("access").Exclude("_id"))
                .ToListAsync();
            foreach (var employee in list)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
