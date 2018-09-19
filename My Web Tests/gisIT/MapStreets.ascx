<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MapStreets.ascx.cs" Inherits="MAPS" %>
<!DOCTYPE html>
<html>
<head>
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <!--The viewport meta tag is used to improve the presentation and behavior of the samples 
    on iOS devices-->
    <meta name="viewport" content="initial-scale=1, maximum-scale=1,user-scalable=no">
    <title>StreetSearch Tool</title>

    <script src="http://js.arcgis.com/3.14/"></script>

    <script src="StreetSearch.js"></script>
</head>

<body >
    <div class="Widget_Body" dir="rtl">
        <table>

            <tr>
                <td style="line-height: 1.5;">البلدية
                </td>
                <td>
                    <select id="cmbMunc" class="DropDownList Arrow" name="NamecmbMunc" style="width: 150px" >
                        <option></option>
                    </select>
                </td>
                <td rowspan="3">
                   
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:Button ID="Button1" runat="server" AutoPostBack="true" OnClick="Button1_Click" Text="Button" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                   
                </td>
            </tr>

            <tr>
                <td style="line-height: 1.5;">الحى
                    
                </td>
                <td>
                    <select id="cmbDist" class="DropDownList Arrow" name="NamecmbDist" style="width: 150px">
                        <option></option>
                    </select>
                </td>
            </tr>

            <tr>
                <td style="line-height: 1.5;">الشارع
                </td>
                <td>
                    <select id="cmbStreet" class="DropDownList Arrow" name="NameStreet" style="width: 150px">
                        <option></option>
                    </select>
                </td>
            </tr>
        </table>
        <%-- <div id="mapDiv" style="width: 500px; height: 300px">
                    </div>--%>
    </div>
</body>
</html>
