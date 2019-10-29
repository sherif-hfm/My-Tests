using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq.Expressions;
using System.Collections;
using System.Dynamic;
using System.Threading;

namespace MongoDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddData();
            //GetData();
            //ReplaceData();
            //DeleteData();
            //AddDynamicData();
            //UpdateData();
            //GetDynamicData();
            //UpdateDynamicData();
            //ReplaceDynamicData();
            //FindData();
            //FindByNested<Worker>(w => w.Address.Town == "Town99");
            //FindData();
            //GetDynamicData2();
            //GetDataPaging();
            //DateType();
            //UpdateData2();
            UpdateSubDoc();
            Console.ReadLine();
        }

        private static void GetDataPaging()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<Worker>("Workers");
            var result2 = collection.Find(w => w.WorkerId != 0).Skip(5).Limit(10).ToList();
        }

        private static  void FindData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<BsonDocument>("Workers");
            BsonDocument filter = new BsonDocument() { { "Address.Town", "Town99" } };
            var cursor = collection.Find(filter).ToList();
        }

        private static void FindByNested<T>(Expression<Func<T, bool>> filter)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<T>("Workers");
            var data = collection.Find(filter).ToList();

        }

        private static void DeleteData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<Worker>("Workers");
            collection.DeleteOne(w => w.WorkerId == 5001);
            //collection.DeleteMany(w => w.WorkerId > -1);
        }

        private static void ReplaceData()
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
            for (int i = 0; i < 100; i++)
            {
                Worker worker = new Worker() { WorkerId = i, WorkerName = "Worker " + i.ToString(), Address = new Address() { Town = "Town" + i.ToString() } };
                collection.InsertOne(worker);
            }
        }

        public static void UpdateData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<Worker>("Workers");
            var filter = Builders<Worker>.Filter.Where(w => w.WorkerId == 99);
            //var update = Builders<Worker>.Update.Set("WorkerName", "KOKO97").Set("Age", "97");
            List<UpdateDefinition<Worker>> defs = new List<UpdateDefinition<Worker>>();
            defs.Add(Builders<Worker>.Update.Set("WorkerName", "KOKO96"));
            defs.Add(Builders<Worker>.Update.Set("Age", "96"));
            var update = Builders<Worker>.Update.Combine(defs);
            var result = collection.UpdateOne(filter, update);
        }

        public static void UpdateData2()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<dynamic>("Workers");
            var filter = new BsonDocument() { { "WorkerId", 99} };
            var newWorker = new { WorkerName = "Worker 995" };
            var newValue = new BsonDocument { { "$set", newWorker.ToBsonDocument() } };
            var result = collection.UpdateOne(filter, newValue);
        }

        private static void AddDynamicData()
        {
            var client = new MongoClient("mongodb://localhost:27017"); 
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<dynamic>("Dynamic");
            var worker1 = new { _id = Guid.NewGuid().ToString(), WorkerId = 1, WorkerName = "Worker 1", Address = new { Town = "Town1" },MoreInfo=new Worker() };
            var car1 = new {_id= Guid.NewGuid().ToString(), CarId = 1, CarName = "Car 1", CarPrice = 10.25, Address = new { Street = "Street1" }, MoreInfo = new Car() };
            collection.InsertOne(worker1);
            collection.InsertOne(car1);
            
        }

        private static void GetDynamicData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<dynamic>("Dynamic");
            var filter = Builders<dynamic>.Filter.Eq("CarId",1) | Builders<dynamic>.Filter.Eq("WorkerId", 1);
            var result2 = collection.Find(filter).ToList();
        }

        private static void GetDynamicData2()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<dynamic>("Dynamic");
            //var filter = Builders<dynamic>.Filter.Eq("CarId", 1) | Builders<dynamic>.Filter.Eq("WorkerId", 1);
            //BsonDocument filter = new BsonDocument() { { "CarId", 1 } };
            //BsonDocument filter = new BsonDocument() { { "Address", new BsonDocument() { { "Town", "Town1" } } } };
            BsonDocument filter = new BsonDocument() { { "Address.Town", "Town1" } };
            var result2 = collection.Find(filter).ToList();
        }

        private static void UpdateDynamicData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<dynamic>("Dynamic");
            var filter = Builders<dynamic>.Filter.Eq("CarId", 1) ;
            var update = Builders<dynamic>.Update.Set("CarName", "KOKO1");
            var result = collection.UpdateOne(filter, update);

        }

        private static void ReplaceDynamicData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<dynamic>("Dynamic");
            var filter = Builders<dynamic>.Filter.Eq("CarId", 1);
            var result2 = collection.Find(filter).First() ;
            result2.CarName = "KOKO12";
            collection.ReplaceOne(filter, result2);
        }

        private static void DateType()
        {
            var ui = Thread.CurrentThread.CurrentCulture;
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<DateInfo>("DateInfo");
            collection.InsertOne(new DateInfo() { ItemId = "a", ItemDate = DateTime.Now });
            var query2 = (from w in collection.AsQueryable() where w.ItemId == "a" select w).ToList(); // date return as utc
        }

        public void UpdateOne<T>(string collectionName, Expression<Func<T, bool>> filterEx, Dictionary<string, object> newFieldData)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<T>(collectionName);
            List<UpdateDefinition<T>> defs = new List<UpdateDefinition<T>>();
            foreach (var field in newFieldData)
            {
                defs.Add(Builders<T>.Update.Set(field.Key, field.Value));
            }
            var updateDef = Builders<T>.Update.Combine(defs);
            var result = collection.UpdateOne<T>(filterEx, updateDef);
        }
        

        public static void UpdateSubDoc()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Db1");
            var collection = db.GetCollection<dynamic>("Workers");
            BsonDocument filter = new BsonDocument() { { "WorkerId", 99 } };
            string json1 = Resource1.json2;
            BsonDocument newValues2 = BsonDocument.Parse(json1);
            BsonDocument newValues = new BsonDocument { { "$set", new BsonDocument { { "Address.Town", "Town03" }, { "Address.BuildingNo", "3" } } } };
            var result = collection.UpdateOne(filter, newValues2);
        }
    }
}
