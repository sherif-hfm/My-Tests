using System.Web.Mvc;

namespace MVC5Routeing.Areas.Warehouses
{
    public class WarehousesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Warehouses";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Warehouses_default",
                "Warehouses/{controller}/{action}/{id}",
                new { controller = "Home" , action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}