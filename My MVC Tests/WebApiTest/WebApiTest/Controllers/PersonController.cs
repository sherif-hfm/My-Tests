using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    public class PersonController : ApiController
    {

        [Route("Person/GetPersonInfo/{_personId}")]
        [HttpGet]
        public PersonInfo GetPersonInfo(int _personId)
        {
            return new PersonInfo() { PersonId = _personId.ToString() };
        }
    }

    public class PersonInfo
    {
        public string PersonId { get; set; }
    }
}
