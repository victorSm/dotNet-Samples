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
    class test2
    {
 /*       public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }   
*/
        public static async Task MainAsync(string[] args)
        {
            //var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient();

            var db = client.GetDatabase("test");
            var col = db.GetCollection<Employee>("Employees");

            var employee = new Employee
            {
                name = "Witold",
                badge = 681811,
                access = "Engineer",
                //metadata = new BsonDocument("Employee training completed date", DateTime.Now)
            };

            await col.InsertOneAsync(employee);
        }
    }
}

