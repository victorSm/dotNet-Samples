using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace BadgeScannerApi.Models
{
    public class Employee
    {
        public ObjectId _id { get; set; }
        public int badge { get; set; }
        public string name { get; set; }
        public string access { get; set; }
    }
}