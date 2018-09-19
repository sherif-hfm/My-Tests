<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PageMethod.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"> </script>
    <script type="text/javascript">
        function GetData() {
            $.ajax({
                type: "POST",
                url: "Handler.ashx/GetDate",
                data: "{data:'\"Posted Data\"'}",
                contentType: "text/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    console.log(msg);
                    //$("#result").text(msg.d);
                },
                error: function (msg) {
                    console.log(msg);
                },
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="result">
        
    </div>
        <input id="Button1" type="button" value="Get Data" onclick="GetData()" />
    </form>
</body>
</html>
