<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UserControlsWeb.index" %>

<%@ Register Assembly="UserControls" Namespace="UserControls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:RmTextBox ID="RmTextBox1" runat="server"></cc1:RmTextBox>
        <cc1:RmControl ID="RmControl1" runat="server" />
    </div>
    </form>
</body>
</html>
