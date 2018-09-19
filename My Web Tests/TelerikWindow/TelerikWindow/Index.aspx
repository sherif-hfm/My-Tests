<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TelerikWindow.Index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function ShowWin() {
            console.log('ShowWin <%=win1.ClientID%>');
                var RadWindow = $find("<%=win1.ClientID%>");
                RadWindow.show();
           
        }

        function ShowWin2() {
            console.log('ShowWin <%=win2.ClientID%>');
            var RadWindow = $find("<%=win2.ClientID%>");
            RadWindow.show();

        }

        function winClosed(sender,args)
        {
            var txt1 = document.getElementById('txt1');
            txt1.value = args._argument;
        }
    </script>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <%--    <asp:Button ID="btnShow" runat="server" Text="Show After Postback" OnClick="btnShow_Click" />
        <input id="Button1" type="button" value="Show" onclick="ShowWin();" />--%>
    <div>
        <telerik:radwindowmanager runat="server"></telerik:radwindowmanager>
        <telerik:radwindow runat="server" id="win1" NavigateUrl="index2.aspx" OnClientClose="winClosed" >
        
        </telerik:radwindow>

         <telerik:RadAjaxPanel runat="server" width="300px" height="200px">
             <telerik:radwindow runat="server" id="win2" OnClientClose="winClosed" >
            <ContentTemplate>
               <asp:Button ID="Button1" runat="server" Text="Button"></asp:Button>
            </ContentTemplate>
        </telerik:radwindow>
         </telerik:RadAjaxPanel>
         
    </div>
        <hr />
        <input id="btnShowWin" type="button" value="ShowWin" onclick="ShowWin()" /><br />
        <input id="txt1" type="text" /><br />
        <input id="btnShowWin" type="button" value="ShowWin" onclick="ShowWin2()" /><br />
    </form>

</body>
</html>
