<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AJAXTest.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.11.3.js"></script>
</head>
<body>
    <script type="text/javascript">

        var xmlhttp;
        var xmls = new XMLSerializer();
        function btnClick(e)
        {
            xmlhttp = new XMLHttpRequest();
            xmlhttp.open("GET", "Data.xml", true);
            xmlhttp.onreadystatechange = requestDone;
            xmlhttp.send();
            
        }

        function requestDone(e)
        {
            if (xmlhttp.responseXML != null)
            {
                var obj = $.parseXML(xmlhttp.responseText);
                console.log(obj);
            }
        }

    </script>
    <form id="form1" runat="server">
        <input id="Button1" type="button" value="button" onclick="btnClick();" />
    <div>
    
    </div>
    </form>
</body>
</html>
