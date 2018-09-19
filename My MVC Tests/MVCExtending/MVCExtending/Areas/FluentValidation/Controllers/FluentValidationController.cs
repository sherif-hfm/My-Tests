using System.Web.Mvc;
using MVCExtending.Areas.FluentValidation.Models;

namespace MVCExtending.Areas.FluentValidation.Controllers
{
    public class FluentValidationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            return View(contact);
        }
    }
}
