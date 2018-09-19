<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="WcfAjaxCall.index2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"> </script>
</head>
<body>
   <form id="form1" runat="server">
    <div>
    <input id="btnGetData" type="button" value="Get Data" onclick="GetData()" /> 
    <input id="txtdata" type="text" />
    </div>
    </form>
    <script type="text/javascript">

        var DataStr = JSON.stringify({ userIdType: '1', userId: '1089067605' });
        function GetData() {

            $.ajax({
                type: 'POST', //GET or POST or PUT or DELETE verb
                url: 'http://localhost:8020/TLS/TLSService.svc/web/GetAllowServiceLicenses',
                data: DataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    console.log(msg);
                },
                error: function (msg) {
                    console.log(msg);
                }
            });
        }

    </script>
</body>
</html>
