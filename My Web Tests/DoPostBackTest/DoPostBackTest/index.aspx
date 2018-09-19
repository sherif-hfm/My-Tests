<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DoPostBackTest.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"> </script>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:Button ID="btn1" runat="server" Text="Button" OnClick="btn1_Click"  />
        <asp:HiddenField ID="hdn1" runat="server" />
        <br />
        <input id="btnPost" type="button" value="Post" onclick="Post3()" />

        <div style="display:none">
            <asp:Button ID="hdnButton" runat="server" Text="" ClientIDMode="Static" OnClick="hdnButton_Click" />
        </div>
        <br />
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit4" OnClientClick="return Post4();" />
        </div>

        <br />
        <div>
            <asp:Button ID="btnSubmit5" runat="server" Text="Submit5"  />
        </div>
        

    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=btnSubmit5.ClientID%>").on("click", function (event) {
                Post5(event);
            });
            $("#<%=btnSubmit5.ClientID%>").on("click", function (event) {
                Post6(event);
            });
        });
        function Post() {
            var postStr = document.getElementById("<% =hdn1.ClientID %>").value;
            console.log(postStr);
             eval(postStr);
        }

        function Post2() {
            __doPostBack("<%= Page.ClientID %>", "EventArgs")
        }

        function Post3() {
            console.log("Post3");
            $('#<%= hdnButton.ClientID%>').click();
        }

        function Post4() {
            return false;
        }

        function Post5(event) {
            //event.returnValue = false;
            //return false;
            event.preventDefault();
            //event.stopImmediatePropagation();
            
        }

        function Post6(event) {
            alert("Post6");
        }
    </script>
</body>
</html>
