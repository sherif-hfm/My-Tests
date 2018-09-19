<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Index.aspx.cs" Inherits="jQueryTest.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.11.3.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    <div>
    <script>
        function MyClass() {
            this.asd = "5";
        }
        var myvar = new MyClass();
        
        var myvar2 = new Object();
        myvar2.Data = "123";
        myvar.asd
        
        msg();
        function msg()
        {
            console.log(this);
            if(myvar == NaN)
        }
        //$(document).ready(function () { alert(this.Data); })
    </script>
    </div>
    </form>
</body>
</html>
