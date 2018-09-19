<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ServerControlTest.Index" %>

<%@ Register Assembly="ServerControls" Namespace="ServerControls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <cc1:CustomControl1 ID="CustomControl1" Text="Ctrl1" runat="server" OnClientClick="btn_onclick1" OnClick="CustomControl1_Click" >
                <NestedControl />
            </cc1:CustomControl1>
            <cc1:CustomControl2 ID="CustomControl2" runat="server" />
        </asp:Panel>
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            var ctrl1 = FindCtrl('<%=CustomControl1.ClientID %>');
            //ctrl1.set_Text("Ctrl2");
        });
        
        function btn_onclick1(sender, e) {
            //sender.set_Text("Ctrl2");
            //console.log(e.target);
            //console.log($(sender));
            //console.log(sender.get_Text());
            //console.log(sender.get_element().id);
            //console.log(sender.GetId());
            //console.log(sender.Button);
            //return false;

        }
    </script>
</body>
</html>
