<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ITextSharp.index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <telerik:radeditor runat="server" ID="editor" OnExportContent="editor_ExportContent">
            <exportsettings>
                <pdf pageheight="297mm" pagewidth="210mm" papersize="A4" DefaultFontFamily="Tahoma">
                </pdf>
            </exportsettings>
            <Content>
</Content>

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
        </telerik:radeditor>
    </div>
        <telerik:radbutton id="btnSave" runat="server" text="Save" OnClick="btnSave_Click"></telerik:radbutton>

    </form>
</body>
</html>
