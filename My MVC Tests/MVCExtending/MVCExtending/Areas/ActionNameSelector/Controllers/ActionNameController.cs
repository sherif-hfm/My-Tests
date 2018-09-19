using System.Web.Mvc;
using MVCExtending.Areas.ActionNameSelector.Utility;

namespace MVCExtending.Areas.ActionNameSelector.Controllers
{
    public class ActionNameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Product]
        //[ActionName("Product")]
        public ActionResult Product(int productId)
        {
            return Content("You asked for product #" + productId);
        }
    }
}
