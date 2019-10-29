using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FileUpload.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("test")]
        [HttpGet]
        public IHttpActionResult test()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello Web Api");
        }

        [Route("upload")]
        [HttpPost]
        public Task<IHttpActionResult> Upload()
        {
            HttpRequestMessage request = this.Request;

            var result= this.Request.Content.ReadAsByteArrayAsync().Result;
            File.WriteAllBytes(@"c:\temp\1.jpg", result);
            
            return Task.FromResult<IHttpActionResult>(Ok());
        }

        [Route("upload2")]
        [HttpPost]
        public async Task<IHttpActionResult> Upload2()
        {
           
            Dictionary<string, IEnumerable<string>> ss = this.Request.Headers.ToDictionary(a => a.Key, a => a.Value);
            var filename= this.Request.Headers.GetValues("fileName").First();
            var result = await this.Request.Content.ReadAsByteArrayAsync();
            File.WriteAllBytes(@"c:\temp\" + filename, result);

            return Ok();
        }

        [Route("upload3")]
        [HttpPost]
        public async Task<IHttpActionResult> Upload3()
        {
            //fsutil file createnew c:\file1.dat 136870912
            //https://stackoverflow.com/questions/43250721/web-api-simplest-way-to-pickup-a-multipart-form-data-response
            //https://dejanstojanovic.net/aspnet/2018/february/multiple-file-upload-with-aspnet-webapi/
            try
            {
                var data = await Request.Content.ReadAsMultipartAsync();
                foreach (var content in data.Contents)
                {
                    var fieldName = content.Headers.GetValues("Content-Disposition").First().Split(';')[1].Split('=')[1].Replace("\"", "");
                    if (fieldName == "FileData")
                    {
                        var filename = content.Headers.GetValues("Content-Disposition").First().Split(';')[2].Split('=')[1].Replace("\"", "");
                        var filedata = await content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(@"c:\temp\" + filename, filedata);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            
            return Ok();
        }
    }
}
