using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    public class Car
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
    }
}
