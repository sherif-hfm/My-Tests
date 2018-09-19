<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl.ascx.cs" Inherits="WebUserControl.WebUserControl" %>

<script>
    function DoClick() {
        //alert("DoClick");
        //__doPostBack('<%= this.ClientID%>', 'Event1');
        //var btn = document.getElementById('<%= Button1.ClientID%>');
        //btn.click();
        var eventTxt = "<%= Page.ClientScript.GetPostBackEventReference(this, "Event1")%>";
        eval(eventTxt);
    }
</script>

<input id="btn1" type="button" value="Save" onclick="DoClick()" />
<div style="display:none">
    <asp:Button ID="Button1" runat="server" Text="Button"  />
</div>

