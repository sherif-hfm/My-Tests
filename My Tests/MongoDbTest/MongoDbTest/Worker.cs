using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    public class Worker
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }

        public Address Address { get; set; }

        public int Age { get; set; }

    }

    public class Address
    {
        public string Town { get; set; }
    }
}
