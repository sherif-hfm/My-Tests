using System.Threading;
using System.Web.Mvc;
using MVCExtending.Areas.TimingFilter.Utility;

namespace MVCExtending.Areas.TimingFilter.Controllers
{
    public class TimingFilterController : Controller
    {
        [ExecutionTiming]
        public ActionResult Index()
        {
            Thread.Sleep(100);
            return View();
        }
    }
}
