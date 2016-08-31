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
    class InsertMany
    {
 /*      static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }*/

        public static async Task MainAsync(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("test");
            var col = db.GetCollection<Employee>("Employees");

            var employee1 = new Employee
            {
                name = "Victor Senior",
                badge = 938438,
                access = "Admin",
                //metadata = new BsonDocument("Senior Engineer", DateTime.Today)
            };

            var employee2 = new Employee
            {
                name = "Dayana",
                badge = 938438,
                access = "Controls",
                //metadata = new BsonDocument("Senior Controls Engineer, PeopleSoft:", 658185)
            };

            var employee3 = new Employee
            {
                name = "Victor Jr",
                badge = 156743,
                access = "Engineer",
                //metadata = new BsonDocument("Senior Controls Engineer, PeopleSoft:", 658185)
            };

            await col.InsertManyAsync(new[] { employee1, employee2});
        }
    }
}
