<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FineUploaderMulti.Index" %>

<%@ Register Src="~/RmMultiUploader.ascx" TagPrefix="uc1" TagName="RmMultiUploader" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblSession" runat="server" Text=""></asp:Label>
        <uc1:RmMultiUploader runat="server" id="RmMultiUploader" />
        <br />
       <%-- <asp:Button ID="btnPostBack" runat="server" Text="PostBack" /><br />
        <asp:Button ID="btnBind" runat="server" Text="Bind" OnClick="btnBind_Click" />--%>
    </div>
    </form>
</body>
</html>
