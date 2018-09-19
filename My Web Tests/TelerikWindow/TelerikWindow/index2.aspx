<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="TelerikWindow.index2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function CloseWindow() {
            var value = document.getElementById('txt1').value;
            //alert(value);
            var oWindow = GetRadWindow();
            oWindow.close(value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="txt1" type="text" /><br />
        <input id="btn1" type="button" value="Close" onclick="CloseWindow()" />
    </div>
    </form>
</body>
</html>
