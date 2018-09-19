using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;




namespace ServerControls
{
    public class CustomControl3 : WebControl, INamingContainer, IPostBackEventHandler, IPostBackDataHandler, IScriptControl
    {
        private ScriptManager sm;
        private Button btn1 = new Button();
        HtmlImage img = new HtmlImage();

        protected override void OnInit(EventArgs e)
        {
            img.ID = this.ClientID + "_Img";
            Page.RegisterRequiresPostBack(this);
            AddCss();
            base.OnInit(e);
        }

        private void AddCss()
        {
            HtmlLink fancyboxcss = new HtmlLink();
            fancyboxcss.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ServerControls.Scripts.fancybox.jquery.fancybox.css");
            fancyboxcss.Attributes["rel"] = "stylesheet";
            fancyboxcss.Attributes["type"] = "text/css";
            Page.Header.Controls.Add(fancyboxcss);

            HtmlLink esricss = new HtmlLink();
            esricss.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ServerControls.Styles.esri.css");
            esricss.Attributes["rel"] = "stylesheet";
            esricss.Attributes["type"] = "text/css";
            Page.Header.Controls.Add(esricss);
        }

        protected override void CreateChildControls()
        {
            //Image img = new Image();
            //img.ID = this.ClientID + "_Img1";
            //img.ImageUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ServerControls.Images.image_big.jpg");
            //this.Controls.Add(img);

            //btn1.Text = "btn";
            //btn1.ID = this.ClientID + "_btn1";
            //btn1.Click += btn1_Click;
            //this.Controls.Add(btn1);
                       

            base.CreateChildControls();
        }

        void btn1_Click(object sender, EventArgs e)
        {
            DoOnClick(e);
        }

       protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // Test for ScriptManager and register if it exists
                sm = ScriptManager.GetCurrent(Page);

                if (sm == null)
                    throw new HttpException("A ScriptManager control must exist on the current page.");

                sm.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }

       public override void RenderControl(HtmlTextWriter writer)
       {
           // 1
           //writer.Write("RenderControl");
           base.RenderControl(writer);
       }

        protected override void Render(HtmlTextWriter writer)
        {
            // 2

            if (!this.DesignMode)
                sm.RegisterScriptDescriptors(this);

            
            base.Render(writer);
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            //3

            //writer.RenderBeginTag(HtmlTextWriterTag.Div); // add div Begin Tag
            
            writer.AddAttribute("RenderBeginTag-AddAttribute", "Vlaue"); // this Attribute will add  to the first next tag 
            writer.RenderBeginTag("BeginTag"); // open begin tag with name BeginTag
            
            // Another way to open  begin tag and add attribute
            //writer.WriteBeginTag("BeginTag");
            //writer.WriteAttribute("RenderBeginTag-WriteAttribute", "Value"); //  this Attribute will add to Begin Tag
            //writer.Write(HtmlTextWriter.TagRightChar);
            
            base.RenderBeginTag(writer);
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            // 4
            writer.AddAttribute("AddAttributesToRender-AddAttribute", "Value"); // Attribute will add to span Tag
            writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "White"); // add style Attribute to span tag
            //writer.AddAttribute("Onclick", Page.ClientScript.GetPostBackEventReference(this, "Onclick")); // Returns a string that can be used in a client event to cause postback to the server


            base.AddAttributesToRender(writer);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            // 5 inside span
            //var imgLocation=Page.ClientScript.GetWebResourceUrl(this.GetType(), "ServerControls.Images.Location48.png");
            //string fancydiv = string.Format(HtmlResource.div, imgLocation);
            //writer.Write(fancydiv);

           
            //writer.Write("RenderContents");
            base.RenderContents(writer);
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            // 6 inside span

            writer.AddAttribute("RenderChildren-AddAttribute", "Value"); // add attribute to next tag
            writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "White"); // add style Attribute to next tag
            writer.RenderBeginTag(HtmlTextWriterTag.Div); // open div tag
            writer.RenderEndTag(); // close div tag
           
            img.Src = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ServerControls.Images.Location48.png"); // set img src value
            img.RenderControl(writer); // render the img tag
           


            base.RenderChildren(writer);
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {

            writer.RenderEndTag();// close the Begin Tag which opened in RenderBeginTag method
            // or this code
            //writer.WriteEndTag("BeginTag");


            base.RenderEndTag(writer);
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            
        }

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            return true;
        }

        public void RaisePostDataChangedEvent()
        {
            
        }

        public delegate void ClickDelegate(object sender, EventArgs e);
        public event ClickDelegate Click;
        protected virtual void DoOnClick(EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        #region ********************* IScriptControl *********************

        protected virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("ServerControls.CustomControl3", this.ClientID);
            descriptor.AddProperty("MapWindowWidth", this.MapWindowWidth);
            descriptor.AddEvent("OnMapWindowClosed", this.OnMapWindowClosed);
            descriptor.AddElementProperty("ElementProperty", img.ID); // the property value contain the img object 
            descriptor.AddScriptProperty("ScriptProperty", "ScriptPropertyFunc()"); //the property value returns from ScriptPropertyFunc function
            
            return new ScriptDescriptor[] { descriptor };
        }

        IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors()
        {
            return GetScriptDescriptors();
        }

        IEnumerable<ScriptReference> IScriptControl.GetScriptReferences()
        {
            return GetScriptReferences();
        }

        protected virtual IEnumerable<ScriptReference> GetScriptReferences()
        {
            ScriptReference CustomControl3 = new ScriptReference(@"ServerControls.Scripts.CustomControl3.js", "ServerControls");
            ScriptReference fancybox = new ScriptReference(@"ServerControls.Scripts.fancybox.jquery.fancybox.js", "ServerControls");
            ScriptReference jquery = new ScriptReference("ServerControls.Scripts.jquery.js", "ServerControls");
            ScriptReference arcgis = new ScriptReference("ServerControls.Scripts.arcgis.js", "ServerControls");

            return new ScriptReference[] { jquery, fancybox, arcgis,CustomControl3 };

        }

        #endregion

        #region ********************* Properites *********************
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public int MapWindowWidth
        {
            get
            {
                int _mapWindowWidth = ViewState["MapWindowWidth"] == null ? 0 : (int)ViewState["MapWindowWidth"];
                return _mapWindowWidth;
            }

            set
            {
                ViewState["MapWindowWidth"] = value;
            }
        }

        public string OnMapWindowClosed
        {
            get
            {
                string _onMapWindowClosed = ViewState["OnMapWindowClosed"] == null ? "" : (string)ViewState["OnMapWindowClosed"];
                return _onMapWindowClosed;
            }

            set
            {
                ViewState["OnMapWindowClosed"] = value;
            }
        }
        #endregion

        
    }
}
