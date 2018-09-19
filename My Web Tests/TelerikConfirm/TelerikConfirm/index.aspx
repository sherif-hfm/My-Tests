<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TelerikConfirm.index" %>

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
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
            <ConfirmTemplate> 
                            <div class="wAlertBkgrnd">
                                <div id="RadWindowManager2_alerttemplate" class="wAlert">
                                    <div >
                                        <div  dir="rtl" style="text-align:center">{1} </div>
                                        <div >
                                            <a onclick="$find('{0}').close(true)"  href="javascript:void(0)">
                                                <font >موافق</font>
                                            </a>
                                            </div>
                                            <div >
                                            <a onclick="$find('{0}').close(false)"  href="javascript:void(0)">
                                                <font >غير موافق </font>
                                            </a>
                                                 </div>
                                            <div >
                                            <a onclick="$find('{0}').close(false)"  href="javascript:void(0)">
                                                <font >إغلاق</font>
                                            </a>
                                        </div>
                                        <div class="clearFix"></div>
                                    </div>
                                </div>
                            </div> 
                        </ConfirmTemplate> 
        </telerik:RadWindowManager>
    <div>
        <telerik:RadButton id="btnDel" runat="server" Text="Del" OnClientClicking="Confirm" OnClick="btnDel_Click"></telerik:RadButton><br />
        <telerik:RadButton id="btnDel2" runat="server" Text="RadButton"  style="display: none1; position: relative;" OnClick="btnDel2_Click"></telerik:RadButton>
    
    </div>
    </form>
    <script type="text/javascript">
        function Confirm(args) {
            //alert("OK");
            radconfirm('Client radconfirm: Are you sure?', confirmCallBackFn, 330, 180, null, 'Client RadConfirm', "");
            args.set_cancel(true);
        }
        function confirmCallBackFn(args) {
            if (args == true)
                document.getElementById('<%= btnDel2.ClientID %>').click();
            //alert(args);
        }
    </script>
</body>
</html>
