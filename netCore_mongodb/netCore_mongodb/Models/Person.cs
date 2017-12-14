using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCore_mongodb.Models
{
    public class Person
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Idcard { get; set; }
    }
}
