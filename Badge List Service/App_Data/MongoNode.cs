using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Text;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;


namespace BadgeScannerApi
{
    public class MongoNode
    {

        public string dbName { get; set; }

        public string colName { get; set; }

        public IMongoCollection<Models.Employee> collection { get; set; }

        public MongoNode(string dbname, string colname)
        {
            dbName = dbname;
            colName = colname;
        }

        public IMongoCollection<Models.Employee> mongoConnect()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase(dbName);
            collection = db.GetCollection<Models.Employee>(colName);

            return collection;
        }


        public IEnumerable<Models.Employee> GetRequest()
        {

            var collection = mongoConnect();
            var docCount = collection.Count(Builders<Models.Employee>.Filter.Empty);
            var list = collection.Find(Builders<Models.Employee>.Filter.Empty).Project(Builders<Models.Employee>.Projection
                .Include("name").Include("badge").Include("access").Exclude("_id")).As<Models.Employee>().ToList();
            var i = 0;

            Models.Employee[] employee = new Models.Employee[docCount];

            foreach (var emp in list)
            {
                employee[i] = emp;
                i++;
            }
            return employee;
        }

        public IEnumerable<Models.Employee> GetRequest(string key, string id)
        {

            var collection = mongoConnect();

            var docCount = collection.Count(Builders<Models.Employee>.Filter.Empty);
            var list = collection.Find(Builders<Models.Employee>.Filter.Eq(key, id)).Project(Builders<Models.Employee>.Projection
                .Include("name").Include("badge").Include("access").Exclude("_id")).As<Models.Employee>().ToList();
            var i = 0;

            Models.Employee[] employee = new Models.Employee[docCount];

            foreach (var emp in list)
            {
                employee[i] = emp;
                /*if (emp.name == null )
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);                  
                }*/
                i++;
            }
            return employee;
        }

        public IEnumerable<Models.Employee> GetRequest(string key, int id)
        {

            var collection = mongoConnect();

            var docCount = collection.Count(Builders<Models.Employee>.Filter.Empty);
            var list = collection.Find(Builders<Models.Employee>.Filter.Eq(key, id)).Project(Builders<Models.Employee>.Projection
                .Include("name").Include("badge").Include("access").Exclude("_id")).As<Models.Employee>().ToList();
            var i = 0;

            Models.Employee[] employee = new Models.Employee[docCount];

            foreach (var emp in list)
            {
                employee[i] = emp;
                i++;
            }
            return employee;
        }

        
    }
}