<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="jQueryPrint.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl1" runat="server" data-args="asd123" Text="Label"></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return test1();"  >LinkButton</asp:LinkButton>
    </div>
    </form>
    <script type="text/javascript">
        function test1()
        {
            console.log($('#<%=lbl1.ClientID %>').attr('data-args'))
            return false;
        }

    </script>
</body>
</html>
