<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TelerikRadGrid.index" %>

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
        <telerik:radgrid id="grd" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" OnItemCommand="grd_ItemCommand">
             <ClientSettings EnableRowHoverStyle="true">
                        <ClientEvents  />
                    </ClientSettings>
            <mastertableview DataKeyNames="PersonId">
               
                <Columns>
                    <telerik:GridBoundColumn DataField="PersonId"  UniqueName="PersonId" HeaderText="PersonId" >
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PersonName"  UniqueName="PersonName" HeaderText="PersonName" >
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PersonAddress"  UniqueName="PersonAddress" HeaderText="PersonAddress" >
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn >
                        <ItemTemplate>
                            <telerik:RadButton name="Cmd1"  runat="server" Text="Cmd1" CommandName="Cmd1" CommandArgument='<%# DataBinder.Eval(Container,"ItemIndex")%>'  data-RowIndex='<%# DataBinder.Eval(Container,"ItemIndex")%>' AutoPostBack="False" ></telerik:RadButton>
                     </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </mastertableview>
            
        </telerik:radgrid>
    </div>
        
    </form>
     <script type="text/javascript" id="telerikClientEvents1">
         $(document).ready(function () {
             $("[name='Cmd1']").on('click', function () {
                 var rowIndex = $(this).attr('data-RowIndex');
                 var grid = $find("<%=grd.ClientID %>");
                 var masterTable = grid.get_masterTableView();
                 masterTable.fireCommand("Cmd1", rowIndex);
             });
         }
         );
        
</script>
</body>
</html>
