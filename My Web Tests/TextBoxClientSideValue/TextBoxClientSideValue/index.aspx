<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TextBoxClientSideValue.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"> </script>
</head>
<body>
      <script type="text/javascript">
          function SetValue()
          {
              //$("#<%= txtData.ClientID %>").attr('disabled','');
              $("#<%= txtData.ClientID %>").val('asd');
              $("#<%= txtData.ClientID %>").text('asd');
          }

          function ShowValue() {
              
              var value = $("#<%= txtData.ClientID %>").val();
              var text = $("#<%= txtData.ClientID %>").text();
              alert(value);
              alert(text);
              
          }
    </script>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtData" runat="server"  Text="Data1" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtData2" runat="server" ></asp:TextBox>
        <br />
        <input id="Text1" type="text" disabled="disabled" value="html" />
        <br />
        <input id="btnSetValue" type="button" value="Set Value" onclick="SetValue()" />
        <br />
        <input id="btnShowValue" type="button" value="Show Value" onclick="ShowValue()" />
        <br />
        <asp:Button ID="btnPost" runat="server" Text="Post" />
        
    </div>
    </form>
  
</body>
</html>
