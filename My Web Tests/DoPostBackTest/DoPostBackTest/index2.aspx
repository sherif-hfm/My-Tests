<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="DoPostBackTest.index2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </scripts>
        </telerik:RadScriptManager>
    <div>
        <telerik:radajaxpanel runat="server" height="200px" width="300px">

            <telerik:RadTextBox ID="txt1" Runat=server></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="vldtxt1" runat="server" ValidationGroup="Save"  ControlToValidate="txt1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <br />
            <br />
            <telerik:radbutton  runat="server" text="btn2" ID="btn1" ValidationGroup="Save" OnClick="btn1_Click" OnClientClicking="btn1_Click"   ></telerik:radbutton>            
            <script type="text/javascript">
                var allowPost = true;
                function TlsReqStartup() {
                    console.log("TlsReqStartup");
                    allowPost = true;
                }
                Sys.Application.add_load(TlsReqStartup);
                function btn1_Click(sender, args) {
                    console.log("allowPost :" + allowPost)
                    if (allowPost == false) {
                        args.set_cancel(true);
                        return;
                    }

                    if (Page_IsValid) {
                        args.set_cancel(false);
                        allowPost = false;
                    }
                    else {
                        args.set_cancel(true);
                    }
                }
    </script>
        </telerik:radajaxpanel>
    </div>
    </form>
    
</body>
</html>
