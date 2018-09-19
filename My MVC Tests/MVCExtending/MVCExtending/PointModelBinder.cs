using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCExtending
{
    public class PointModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;
            int x = (int)valueProvider.GetValue("X").ConvertTo(typeof(int));
            int y = (int)valueProvider.GetValue("Y").ConvertTo(typeof(int));
            return new Point(x, y);
        }
    }
}