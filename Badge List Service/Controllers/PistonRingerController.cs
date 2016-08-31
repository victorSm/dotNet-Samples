using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Web.Cors;
using System.Web.Http.Cors;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;


namespace BadgeScannerApi.Controllers
{
    [EnableCors("http://localhost:1880",
                null,
                "GET"
                )]
    public class PistonRingerController : ApiController
    {
        // GET: api/PistonRinger
        public IEnumerable<Models.Employee> Get()
        {
            return mongo.GetRequest();
        }

        // GET: api/PistonRinger/name
        [HttpGet]
        public IEnumerable<Models.Employee> GetName(string id)
        {
            return mongo.GetRequest("name",id);
        }

        // GET: api/PistonRinger/access
        [HttpGet]
        public IEnumerable<Models.Employee> GetAccess(string id)
        {
            return mongo.GetRequest("access",id);
        }

        // GET: api/PistonRinger/badge
        [HttpGet]
        public IEnumerable<Models.Employee> GetBadge(int id)
        {
            return mongo.GetRequest("badge", id);
        }


        // POST: api/PistonRinger/Insert
        [EnableCors("http://localhost:1880",
                    "Accept, Origin, Content-Type",
                    "POST",
                    PreflightMaxAge = 10000
                    )]
        [HttpPost]
        public HttpResponseMessage Insert(Models.Employee employee)
        {
            var response = Request.CreateResponse<Models.Employee>(HttpStatusCode.Created, employee);
            var collection = mongo.mongoConnect();
            collection.InsertOne(employee);
            string uri = Url.Link("DefaultApi", new { id = employee.name });
            response.Headers.Location = new Uri(uri);

            return response;          
        }


        // PUT: api/PistonRinger/Update/valEq/keyEq/valSet/keyEq
        [EnableCors("http://localhost:1880",
                    "Accept, Origin, Content-Type",
                    "POST",
                    PreflightMaxAge = 10000
                    )]
        [HttpPost]
        public HttpResponseMessage Update(string keyEq, string valEq, string keySet, string valSet )
        {
            var response = Request.CreateResponse(HttpStatusCode.Accepted);
            var collection = mongo.mongoConnect();
            collection.UpdateOne(
                    Builders<Models.Employee>.Filter.Eq(keyEq, valEq),
                    Builders<Models.Employee>.Update.Set(keySet, valSet)
                );
            string uri = Url.Link("UpdateApi", new { key1 = keyEq, val1 = valEq, key2 = keySet, val2 = valSet });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        // POST: api/PistonRinger/Delete/Id
        [EnableCors("http://localhost:1880",
                    "Accept, Origin",
                    "POST",
                    PreflightMaxAge = 10000
                    )]
        [HttpPost]
        public void Delete(int id)
        {
            var collection = mongo.mongoConnect();
            collection.DeleteOne(Builders<Models.Employee>.Filter.Eq("badge", id));
        }

        MongoNode mongo = new MongoNode("test", "Employees");

    }
}
