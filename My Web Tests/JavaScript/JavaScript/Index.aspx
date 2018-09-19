<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="JavaScript.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <script type="text/javascript">
        var obj1=new Object();
        obj1.id = 2;
        obj1.name = 'ahmed';
        var obj2 = { id: 1, name: 'sherif' };
        console.log(obj1);
        console.log(obj2);
        
        var myclass = function () {
            var var1 = 'var1';
            this.GetId = function () { alert(var1); };
            this.Id = 1;
        };
        var obj = new myclass();
        obj.GetId();
        //alert(var1);
    </script>
</body>
</html>
