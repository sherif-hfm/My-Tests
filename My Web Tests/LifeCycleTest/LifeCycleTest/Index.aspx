<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Index.aspx.cs" Inherits="LifeCycleTest.Index" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    </form>
    <script>
        $(function () {
            $('#<%=Button1.ClientID%>').on('click', function () {
                $('#<%= TextBox1.ClientID%>').attr('value', 'asd')
                alert('click');
            });
        });
    </script>
</body>
</html>
