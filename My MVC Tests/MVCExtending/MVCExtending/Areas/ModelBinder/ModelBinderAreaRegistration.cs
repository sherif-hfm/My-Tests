using System.Drawing;
using System.Web.Mvc;
using MVCExtending.Areas.ModelBinder.Utility;

namespace MVCExtending.Areas.ModelBinder
{
    public class ModelBinderAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "ModelBinder"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ModelBinder_default",
                "ModelBinder/{action}/{id}",
                new { controller = "ModelBinder", action = "Index", id = UrlParameter.Optional }
            );

            ModelBinders.Binders.Add(typeof(Point), new PointModelBinder());
        }
    }
}
