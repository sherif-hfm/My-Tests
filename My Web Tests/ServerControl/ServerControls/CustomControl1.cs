using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CustomControl1 runat=server></{0}:CustomControl1>")]
    public class CustomControl1 : WebControl, IScriptControl, IPostBackEventHandler, IPostBackDataHandler, INamingContainer 
    {
        private ScriptManager sm;

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string OnClientClick
        {
            get
            {
                String s = (String)ViewState["OnClientClick"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["OnClientClick"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            Page.RegisterRequiresPostBack(this);
            AddCss();
            base.OnInit(e);
        }

        private void AddCss()
        {
            HtmlLink CustomControl1css = new HtmlLink();
            CustomControl1css.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ServerControls.Styles.CustomControl1.css");
            CustomControl1css.Attributes["rel"] = "stylesheet";
            CustomControl1css.Attributes["type"] = "text/css";
            Page.Header.Controls.Add(CustomControl1css);
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

        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
                sm.RegisterScriptDescriptors(this);

            // I must set 'Name' attribute to return data when post back
            writer.Write(string.Format("<input name='{0}_Text' id='{0}_Text' type='text' value='{1}' />", this.ClientID,this.Text));
            writer.Write(string.Format("<input id='{0}_Button' type='button' value='Save' />", this.ClientID));
            
            // to add controls
            var hdn=new HiddenField();
            hdn.ID="hdn-KOKO";
            
            this.Controls.Add(hdn);
            
            base.Render(writer);
        }

        // to Make Nested Control
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Control NestedControl
        {
            get { return new Control(); }
        }

        protected virtual IEnumerable<ScriptReference> GetScriptReferences()
        {
            ScriptReference customControl1 = new ScriptReference("ServerControls.Scripts.CustomControl1.js", "ServerControls");
            ScriptReference jquery = new ScriptReference("ServerControls.Scripts.jquery.js", "ServerControls");
            //reference.Path = ResolveClientUrl("CustomControl1.js");
            //reference.Path =  "ServerControls.CustomControl1.js";

            return new ScriptReference[] { jquery, customControl1 };
        }

        protected virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("ServerControls.CustomControl1", this.ClientID);
            descriptor.AddProperty("Text", this.Text);
            descriptor.AddProperty("OnClientClick", this.OnClientClick);

            return new ScriptDescriptor[] { descriptor };
        }

        IEnumerable<ScriptReference> IScriptControl.GetScriptReferences()
        {
            return GetScriptReferences();
        }

        IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors()
        {
            return GetScriptDescriptors();
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument == "Onclick")
                DoOnClick(new EventArgs());
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            // add Attribute to control
            writer.AddAttribute("Text", this.Text);
            writer.AddAttribute("Onclick", Page.ClientScript.GetPostBackEventReference(this, "Onclick"));
        }

        public delegate void ClickDelegate(object sender, EventArgs e);
        public event ClickDelegate Click;
        protected virtual void DoOnClick(EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string cdExpanded = postCollection["hdn-KOKO"];
            this.Text = HttpContext.Current.Request.Form[string.Format("{0}_Text",this.ClientID)];
            return true;
        }

        public void RaisePostDataChangedEvent()
        {
            //throw new NotImplementedException();
        }


       
    }
}
