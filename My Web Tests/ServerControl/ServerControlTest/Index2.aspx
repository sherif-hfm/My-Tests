<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index2.aspx.cs" Inherits="ServerControlTest.Index2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="ServerControls" Namespace="ServerControls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div >
        
        <cc1:CustomControl3 ID="CustomControl1" runat="server" OnClick="CustomControl1_Click" MapWindowWidth="770" OnMapWindowClosed="OnMapWindowClosedHandler" />
        <br />
        <cc1:CustomControl3 ID="CustomControl2" runat="server" OnClick="CustomControl1_Click" MapWindowWidth="500" OnMapWindowClosed="OnMapWindowClosedHandler" />
        <br />
        <br />
        <telerik:radbutton runat="server" text="RadButton" Width="500px" ></telerik:radbutton>
    </div>
    </form>
    <script type="text/javascript">

        function OnMapWindowClosedHandler(sender,e)
        {
            sender.set_MapWindowWidth(900);
            console.log("OnMapWindowClosedHandler");
            console.log(sender);
            console.log(e);
        }

        

    </script>
</body>
</html>
