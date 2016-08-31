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
    class ReplaceMany
    {
 /*       static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }*/

        static async Task MainAsync(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("test");
            var col = db.GetCollection<Employee>("Employees");

            var builderFilter = Builders<Employee>.Filter;
            var builderUpdate = Builders<Employee>.Update;

            var result = await col.UpdateManyAsync(
                    builderFilter.Eq("access", "Engineer"),
                    builderUpdate.Set("badge", 656565)
                );
        }
    }
}
