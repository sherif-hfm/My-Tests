<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CallPageWebMethod.index" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="scripts/jquery-3.3.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:WebUserControl1 runat="server" id="WebUserControl1" />
    </form>
</body>
</html>
