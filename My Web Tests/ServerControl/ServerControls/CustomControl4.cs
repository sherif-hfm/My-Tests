using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace ServerControls
{
    public class CustomControl4 : WebControl, INamingContainer, IPostBackEventHandler, IPostBackDataHandler, IScriptControl
    {
        private ITemplate templateValue;
        private TemplateOwner ownerValue;
        
        [Browsable(false),
        PersistenceMode(PersistenceMode.InnerProperty),
        DefaultValue(typeof(ITemplate), ""),
        Description("Control template"),
        TemplateContainer(typeof(TemplateOwner))
        ]
        public virtual ITemplate ItemTemplate
        {
            get
            {
                return templateValue;
            }
            set
            {
                templateValue = value;
            }
        }

        

        public object DataSource { get; set; }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            ITemplate temp = templateValue;
            foreach(var item in (ICollection)this.DataSource)
            {
               
                ownerValue = new TemplateOwner();
                ownerValue.DataItem = item;
                temp.InstantiateIn(ownerValue);
                this.Controls.Add(ownerValue);
            }
        }

        public override void DataBind()
        {
            CreateChildControls();
            ChildControlsCreated = true;
            base.DataBind();
        }

        #region ********************* Implmentation *********************
        public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("ServerControls.CustomControl4", this.ClientID);
            return new ScriptDescriptor[] { descriptor };
        }

        public IEnumerable<ScriptReference> GetScriptReferences()
        {
            ScriptReference jquery = new ScriptReference("ServerControls.Scripts.jquery.js", "ServerControls");
            return new ScriptReference[] { jquery };
        }

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            return true;
        }

        public void RaisePostDataChangedEvent()
        {
        }

        public void RaisePostBackEvent(string eventArgument)
        {
        }

        #endregion
    }

    public class TemplateOwner : WebControl,INamingContainer
    {
        object mDataItem;
        public Object DataItem
        {
            get
            {
                return mDataItem;
            }
            set
            {
                mDataItem = value;
            }
        }
        protected override void CreateChildControls()
        {

        }
    }
}
