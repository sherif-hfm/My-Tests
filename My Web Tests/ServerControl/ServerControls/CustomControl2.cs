using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CustomControl2 runat=server></{0}:CustomControl2>")]
    [ToolboxItem(false)] 
    [ParseChildrenAttribute(ChildrenAsProperties = false)]
    public class CustomControl2 : CompositeControl, INamingContainer
    {

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<RenderBeginTag>");
            base.RenderBeginTag(writer);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("<RenderContents>");
            base.RenderContents(writer);
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("<RenderEndTag>");
            base.RenderEndTag(writer);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<Render>");
            base.Render(writer);
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            writer.Write("<RenderChildren>");
            base.RenderChildren(writer);
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            writer.Write("<RenderControl>");
            base.RenderControl(writer);
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.Write("<AddAttributesToRender>");
            base.AddAttributesToRender(writer);
        }
    }


}
