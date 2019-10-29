using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LocationApis.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            // do what is needed
            return this.Unauthorized();
        }

        [Route("SetLocation")]
        [HttpGet]
        public IHttpActionResult SetLocation(string latitude,string longitude)
        {
            //api/SetLocation?latitude=1&longitude=2
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Location");
            var collection = db.GetCollection<dynamic>("Location");
            collection.InsertOne(new { latitude= latitude, longitude= longitude,Time=DateTime.Now });
            return Content(System.Net.HttpStatusCode.OK, latitude + "-" + longitude);
        }

        [Route("GetLocation")]
        [HttpGet]
        public IHttpActionResult GetLocation()
        {
            //api/GetLocation
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Location");
            var collection = db.GetCollection<dynamic>("Location");
            var result = (from w in collection.AsQueryable()
                          select w).ToList().Last();
            return Content(System.Net.HttpStatusCode.OK, new { latitude=result.latitude, longitude= result.longitude, Time=result.Time });
        }
    }
}
