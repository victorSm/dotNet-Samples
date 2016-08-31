using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDB_tests
{
    class Employee
    {
        public string name { set; get; }
        public Int32 badge { set; get; }
        public string access { set; get; }
    }
}
