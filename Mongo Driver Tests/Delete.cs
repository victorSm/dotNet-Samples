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
    class Delete
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
            var id = new ObjectId("000000000000000000000000");
            var result = await col.DeleteOneAsync(Builders<Employee>.Filter.Eq("_Id", id ));
        }
    }
}
