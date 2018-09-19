<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TelerikRadCombobox.index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.11.3.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </scripts>
        </telerik:RadScriptManager>
    <div>
        <telerik:radcombobox id="RadComboBox1" runat="server" Filter="Contains" CheckBoxes="True" OnClientItemChecked="ComboBox_ItemChecked" Sort="Ascending">
            <Items>
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem1" Value="RadComboBoxItem1" />
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem2" Value="RadComboBoxItem2" />
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem3" Value="RadComboBoxItem3" />
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem4" Value="RadComboBoxItem4" />
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem5" Value="RadComboBoxItem5" />
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem6" Value="RadComboBoxItem6" />
            </Items>
        </telerik:radcombobox>
    </div>
        <div id="divItems">

        </div>
        <script type="text/javascript" id="telerikClientEvents1">

            function ComboBox_ItemChecked(sender, args) {
                var combo = $find("<%= RadComboBox1.ClientID %>");
                var item = combo.findItemByValue('1');
                var items = combo.get_items();
                $('#divItems').empty();
                items.forEach(function (item) {
                    var isChecked = item.get_checked();
                    if(isChecked==true)
                    {
                        var itemText = item.get_text() +' , ';
                        $('#divItems').append(itemText);
                    }
                });
                //combo.trackChanges();
                //item.set_checked(false);
                //combo.commitChanges();
            }
</script>
    </form>
</body>
</html>
