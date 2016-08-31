using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace BadgeScannerApi.Controllers
{
    public class SeriousNukeController : ApiController
    {
        // GET: api/SeriousNuke
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SeriousNuke/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SeriousNuke
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SeriousNuke/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SeriousNuke/5
        public void Delete(int id)
        {
        }
    }
}
