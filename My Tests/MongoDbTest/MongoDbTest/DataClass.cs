using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    public class DateInfo
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string ItemId { get; set; }
        public DateTime ItemDate { get; set; }
    }
}
