<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TelerikAsyncUpload.Index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server">
            <scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </scripts>
        </telerik:radscriptmanager>
        <div>
            <asp:Repeater ID="rpt" runat="server"  >
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" Visible='<%# (bool)Eval("IsUploaded") %>' runat="server" data-FileGuid='<%# Eval("FileGuid") %>' OnClick="btnDelete_Click"><%# Eval("FileName") %></asp:LinkButton><br />
                    <telerik:radasyncupload runat="server" Visible='<%# !(bool)Eval("IsUploaded") %>'  id="upload1" maxfileinputscount="1" data-FileGuid='<%# Eval("FileGuid") %>' >
                    </telerik:radasyncupload>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Button ID="btnCheck" runat="server" Text="Check" /><br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
