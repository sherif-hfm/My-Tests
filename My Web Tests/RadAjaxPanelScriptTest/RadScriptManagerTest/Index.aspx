<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="RadScriptManagerTest.Index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControl1.ascx" TagPrefix="uc1" TagName="UserControl1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" >
            <scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference  Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
              <%--  <asp:ScriptReference Path="jquery-1.11.3.js" />
                <asp:ScriptReference Path="My.js" />--%>
            </scripts>
        </telerik:RadScriptManager>
        
        <telerik:radajaxloadingpanel runat="server" id="loading" skin="Default" IsSticky="True">
           <div style="width:800px;height:630px"></div>
        </telerik:radajaxloadingpanel>

        <telerik:radajaxpanel runat="server" height="200px" width="300px" HorizontalAlign="NotSet" LoadingPanelID="loading"  >
            <div style="width:800px"></div>
            <asp:Button ID="btnViewText" runat="server" Text="View Text Box" OnClick="btnViewText_Click"></asp:Button>
            <br />
            <%--<asp:TextBox ID="txt1" number runat="server" Visible="false"></asp:TextBox>--%>

                <uc1:UserControl1 runat="server" id="UserControl1" Visible ="false"  />
            <telerik:RadScriptBlock runat="server">
                <script>
                    //$.getScript("My.js");
                </script>
            </telerik:RadScriptBlock>
            <script>
                //alert("OK 2");
            </script>
        </telerik:radajaxpanel>

        <script type="text/javascript" >
            //var prm = Sys.WebForms.PageRequestManager.getInstance();
            //prm.add_pageLoaded(PageLoadedEventHandler);
            //function PageLoadedEventHandler() {
            //    //alert("Sys.WebForms.PageRequestManager.getInstance");
            //}
        </script>
        
    <div>
    </div>
        <%--<script src="My.js"></script>--%>
    </form>
</body>
</html>
