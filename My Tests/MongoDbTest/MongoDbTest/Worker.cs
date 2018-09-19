using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    public class Worker
    {
        public ObjectId _id { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
    }
}
