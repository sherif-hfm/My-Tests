<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl1.ascx.cs" Inherits="RadScriptManagerTest.UserControl1" %>

<asp:TextBox ID="txt" runat="server"></asp:TextBox>
<br />
<asp:Button ID="btnShowText" runat="server" Text="Button" OnClick="btnShowText_Click" />


<script type="text/javascript">
    alert('UserControl1 Script');
       
</script>