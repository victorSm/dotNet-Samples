using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace MongoDB_test1
{
    class Find
    {
/*        static void Main(string[] args)
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

            var list = await col.Find(new BsonDocument()).ToListAsync();
            foreach(var employee in list)
            {
                Console.WriteLine(employee);
            }

/*            using (var cursor = await col.Find(new BsonDocument()).ToCursorAsync())
            {
                while(await cursor.MoveNextAsync())
                {
                    foreach(var employee in cursor.Current)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }*/
        }
    }
}
