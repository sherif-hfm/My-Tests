<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchPlans.ascx.cs" Inherits="SearchPlans" %>

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
    <script src="SearchPlans.js"></script>
    <script src="StreetSearch.js"></script>
</head>
<body>
    <div class="Widget_Body" dir="rtl">
        <div id="PlansSearch" class="Widget_Body">
            <table>
                <tr>
                    <td style="line-height: 1.5;">المخطط        
                    </td>
                </tr>
                <tr>
                    <td>
                        <select id="cmbPlans" class="DropDownList Arrow" name="NamecmbPlans">
                            <option></option>
                        </select>

                    </td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </tr>
                <tr>
                    <td style="line-height: 1.5;">القطعة
                    </td>
                </tr>
                <tr>
                    <td>
                        <select id="cmbVersion" class="DropDownList Arrow" name="namecmbVersion">
                            <option></option>
                        </select>
                    </td>
                </tr>

            </table>
            <%-- <div id="mapDiv" style="width: 500px; height: 300px">
        </div>--%>
        </div>
    </div>
    </body>
</html>
