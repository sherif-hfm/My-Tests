<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AddDynamicControls.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" />
    </form>
</body>
</html>
