<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index4.aspx.cs" Inherits="ServerControlTest.Index4" %>
<%@ Register Assembly="ServerControls" Namespace="ServerControls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    <cc1:CustomControl4  id="ctrl1" runat="server"  >
        <ItemTemplate>
            <div>hello  <%# Eval("Name")%></div>
        </ItemTemplate>
    </cc1:CustomControl4>
    </div>
    </form>
</body>
</html>
