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
    class Replace
    {
/*        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }  */

        static async Task MainAsync(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("test");
            var col = db.GetCollection<Employee>("Employees");

            var newEmployee = new Employee
            {
                name = "Witold",
                badge = 236367,
                access = "Engineer",
                //metadata = new BsonDocument("Hire date", DateTime.Parse("01/23/2001"))
            };

            var result = await col.ReplaceOneAsync(
                    Builders<Employee>.Filter.Eq("name", "Witold"),
                    newEmployee
                );
        }
    }
}
