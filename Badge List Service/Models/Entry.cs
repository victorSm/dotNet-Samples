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
    public class Entry
    {
        public string key { get; set; }
        public Object value { get; set; }
        public string name { get; set; }
    }
}