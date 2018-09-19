<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PreventMultiPost.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <label>Name</label>
        <asp:TextBox ID="txt1" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return Save();" OnClick="btnSave_Click" /><br />
        <span id="msg" runat="server" style="color:red"> </span>
        <asp:HiddenField ID="hdnAllowSave" runat="server" Value="true" />
    </div>
    </form>
    <script type="text/javascript">
        function Save()
        {
            if ($("#<%=hdnAllowSave.ClientID%>").val() == 'true') {
                console.log("allow save true");
                $("#<%=hdnAllowSave.ClientID%>").val('false');
                return true;
            }
            else
            {
                console.log("allow save false");
                return false;
            }
        }
    </script>
</body>
</html>
