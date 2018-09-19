<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>





<html>
<body>
    <form runat="server">
        <h3>Enter name:
            <input name="_name" id='_name' runat="server" type="text" />

            Personality:
            <select runat="server" name="_personality" id='_personality'>
                <option>extraverted</option>
                <option>introverted</option>
                <option>in-between</option>
            </select>
            <input type="submit" name="_lookup" value="Submit"></input>
            <p>
                <%
                    if (IsPostBack)
                        Response.Output.Write("Hi {0}, you selected {1}",
                              _name.Value, _personality.Value);
                %>
            </p>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </form>
</body>
</html>
