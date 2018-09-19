<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UpdatePanelTest.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Progress{
            width:100%;
            height:100%;
            top:0px;
            left:0px;
            position:absolute;
            background-color:gray;
            z-index:999999;
            opacity:20;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:TextBox ID="txtMain1" runat="server"></asp:TextBox>
        <br />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div class="Progress">
                    Processing...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
                <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                <asp:GridView runat="server" id="grd1" AutoGenerateColumns="true"></asp:GridView>
                <br />
                <asp:Button runat="server" id="btn1" Text="Button" OnClick="btn1_Click"   />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" id="grd2" AutoGenerateColumns="true"></asp:GridView>
                <br />
                <asp:Button runat="server" id="btn2" Text="Button"  OnClick="btn2_Click"/>
            </ContentTemplate>            
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
