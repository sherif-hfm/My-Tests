<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="JSONTest.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        var person = new Object();
        person.Name = "Sherif";
        person.Age = 39;
        var txt = JSON.stringify(person);
        var person2 = JSON.parse(txt);
        //alert(person2.Name);
        console.log(person2);
    </script>
    
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
