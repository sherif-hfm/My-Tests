using System.Web.Mvc;
using MVCExtending.Areas.CustomActionResult.Models;
using MVCExtending.Areas.CustomActionResult.Utility;

namespace MVCExtending.Areas.CustomActionResult.Controllers
{
    public class CustomActionResultController : Controller
    {
        public ActionResult Index()
        {
            var model = new Person
            {
                FirstName = "Brad",
                LastName = "Wilson",
                Blog = "http://bradwilson.typepad.com"
            };

            return new XmlResult(model);
        }
    }
}
