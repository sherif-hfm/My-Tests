using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddData();
            GetData();
            //EditData();
            //DeleteData();
        }

        private static void DeleteData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<Worker>("Workers");
            collection.DeleteOne(w => w.WorkerId == 5001);
            //collection.DeleteMany(w => w.WorkerId > -1);
        }

        private static void EditData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<Worker>("Workers");
            var result2 = collection.Find(w => w.WorkerId == 5000).First();
            result2.WorkerName = "Worker 5000_2";
            collection.ReplaceOne(w => w.WorkerId == 5000, result2);
        }

        private static void GetData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<Worker>("Workers");
            var result = collection.Count(w => w.WorkerId != 0);
            var result2 = collection.Find(w => w.WorkerId == 5000).ToList();
            var query2 = (from w in collection.AsQueryable()
                          where w.WorkerId > -1
                          select w).ToList();
         }

        private static void AddData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<Worker>("Workers");
            for (int i = 0; i < 100000; i++)
            {
                Worker worker = new Worker() { WorkerId = i, WorkerName = "Worker " + i.ToString() };
                collection.InsertOne(worker);
            }
        }
    }
}
