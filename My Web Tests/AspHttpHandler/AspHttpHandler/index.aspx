<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AspHttpHandler.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.11.3.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
    </form>
    <script type="text/javascript">
        SendData();
        function SendData() {
            $.ajax({
                url: "Data.file",
                contentType: "application/json; charset=utf-8",
                responseType: "json",
                dataType: "json",
                data: { "Data": "My Data" },
                success: OnComplete,
                error: OnFail
            });
            return false;
        }
        function OnComplete(result) {
            alert('Request OnComplete');
            alert(result.resultData)
        }

        function OnFail(result) {
            alert('Request OnFail');
        }
    </script>
</body>
    
    
</html>
