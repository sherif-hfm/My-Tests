<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OpenMsWordTest.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"> </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="btnOpenWord" type="button" value="OpenWord" onclick="OpenWord();"   />
        <br />
        <asp:Button ID="btnViewImage" runat="server" Text="" style="display:none" OnClick="btnViewImage_Click" />
        <br />
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <br />
        <asp:Image ID="imgDoc" runat="server"  Width="50%" Height="50%" />
    </div>
    </form>
    <script type="text/javascript">

        var ws;
        var connected = false;
        function OpenWord() {
            if (connected == false) {
                ws = new WebSocket("ws://localhost:8080/service");

                ws.onopen = function () {
                    connected = true;
                    console.log("Conected ......");
                    console.log("About to send data");
                    ws.send("OpenMsWordNew-380001");
                    console.log("Message sent!");
                };

                ws.onmessage = function (evt) {
                    var received_msg = evt.data;
                    console.log("Message received = " + received_msg);
                    ws.close();
                    connected = false;
                    $("#<% = btnViewImage.ClientID %>").click();
                };

                ws.onerror = function () {
                    connected = false;
                    console.log("Error ......");
                };

                ws.onclose = function () {
                    connected = false;
                    // websocket is closed.
                    console.log("Connection is closed...");
                };
            }
        }
        
        
        function OpenWord_old()
        {
            var DataStr = JSON.stringify({ _data: '' });
            $.ajax({
                type: 'POST', //GET or POST or PUT or DELETE verb
                url: 'http://localhost:15009/OpenMsWordSrv.svc/web/OpenMsWord',
                data: DataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    console.log('ok');
                    console.log(msg);
                },
                error: function (msg) {
                    console.log('error');
                    console.log(msg);
                }
            });
        }

    </script>
</body>
</html>
