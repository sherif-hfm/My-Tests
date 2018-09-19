<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ArcGISMap.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <script src="fancybox/jquery.fancybox.js"></script>
    <script src="fancybox/jquery.fancybox.pack.js"></script>
    <link href="fancybox/jquery.fancybox.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="btnShowMap" type="button" value="Show Map" />
        <div id="fancybox" style="visibility:visible">
           <%--<iframe src="Map.html" width="600" height="600"></iframe>--%>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#fancybox").hide();
            $("#btnShowMap").on('click', function () {
                //$.fancybox({ type: 'inline', content: $("#fancybox").html() });
                $.fancybox.open({
                    'type': 'iframe', 'href': 'Map.html', 'autoSize': false, 'scrolling': 'no', 'width': 770, 'height': 620,
                    beforeLoad: function () {
                        //alert("OK");
                        //this.width = 800;
                        //this.height = 800;
                    }
                });
                //$("#fancybox").show();
            });
        });
    </script>
</body>
</html>
