<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FancyBoxTest.Index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <script src="fancybox/jquery.fancybox.js"></script>
   <%-- <script src="fancybox/jquery.fancybox.pack.js"></script>--%>
    <script src="fancybox/jquery.mousewheel-3.0.6.pack.js"></script>
    <link href="fancybox/jquery.fancybox.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:Button ID="btnShowWindow" runat="server" Text="Button" OnClick="btnShowWindow_Click" />
       
        <div id="div_small">
            <img  id="img_small" src="image_small.jpg" alt="" />
        </div>
         <telerik:radajaxpanel runat="server" height="200px" width="300px" HorizontalAlign="NotSet">
              <div id="div_big" style="display:none">
            <div>
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                <asp:Label ID="lbl1" runat="server" Text="OK"></asp:Label>
                <img id="img_big" src="image_big.jpg" alt="" height="200px" width="300px" />
            </div>
        </div>
        </telerik:radajaxpanel>
       
      
    </form>
    <script type="text/javascript">
        function ShowWindow() {

            event.preventDefault();
            $.fancybox(
             {
                 type: 'iframe'
                 , content: $("#div_big").html()
                 , autoCenter: true
                 , closeClick: false
                 , closeBtn: false
                 , openEffect: "elastic"
                 , closeEffect: "elastic"
                 , scrollOutside: true
                 , fitToView: true
                 , scrolling: "no"
                 , minHeight: 242
                 , minWidth: 800
                 , helpers: { title: null }
             });

        }
    </script>
</body>
</html>
