<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TelerikEditor.index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="jquery-1.11.3.js"></script>
    <link href="styles.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: AL-Mohanad;
        }
    </style>
</head>
<body>
    <div  class="auto-style1" >السلام عليكم</div>
    <div style="font-family:'Tahoma';"> السلام عليكم</div>
    <div style="font-family:'Times New Roman';"> السلام عليكم</div>
    <div style="font-family:'Andalus'"> السلام عليكم</div>
    <br /><br />
    <form id="form1" runat="server">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server">
            <scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </scripts>
        </telerik:radscriptmanager>
        <telerik:radwindowmanager id="winMngr" runat="server"></telerik:radwindowmanager>
        <div>
            <telerik:radeditor runat="server" id="editor" onexportcontent="editor_ExportContent" language="ar-SA">
            <exportsettings>
            </exportsettings>
           <Content>
               <div style="text-align:right;direction:rtl">
                   <p style="font-family: Arial; margin: 0in; font-size: 9pt;"><span lang="ar-SA" style="direction: rtl; unicode-bidi: embed; background-image: initial; background-attachment: initial; background-size: initial; background-origin: initial; background-clip: initial; background-position: initial; background-repeat: initial;">&nbsp;</span></p>
                <p style="font-family: Arial; margin: 0in; font-size: 9pt;"><span lang="ar-SA" style="direction: rtl; unicode-bidi: embed; background-image: initial; background-attachment: initial; background-size: initial; background-origin: initial; background-clip: initial; background-position: initial; background-repeat: initial;">السلام عليكم&nbsp;</span></p>
                <p style="font-family: Arial; margin: 0in; font-size: 10.5pt;"><span lang="ar-SA" style="direction: rtl; unicode-bidi: embed; background-image: initial; background-attachment: initial; background-size: initial; background-origin: initial; background-clip: initial; background-position: initial; background-repeat: initial;">سعادة المحترم / مدير مركز المعلومات</span></p>
                <p style="font-family: Arial; margin: 0in; font-size: 9pt;"><span lang="ar-SA" style="direction: rtl; unicode-bidi: embed; background-image: initial; background-attachment: initial; background-size: initial; background-origin: initial; background-clip: initial; background-position: initial; background-repeat: initial;">تحية طيبة وبعد ،،،</span></p>
                <p style="margin: 0in; font-size: 9pt;">بخصوص &nbsp; &nbsp; Doc Follow 1 &nbsp; </p>
                <p style="margin: 0in; font-size: 9pt;">خطاب رقم&nbsp; &nbsp;&nbsp;3700092442&nbsp; &nbsp;ارجو المتابعة</p>
               </div>
           </Content>
            <TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
            </telerik:radeditor>
            <br />
            <telerik:radbutton id="btnSave" runat="server" text="Save" onclick="btnSave_Click"></telerik:radbutton>
            <br />
            <br />
            <input id="btnPaste" type="button" value="Paste Html" onclick="InsertSpan();" />
            <br />
            <br />
            <telerik:radbutton id="btnPreview" runat="server" text="Preview" onclick="btnPreview_Click"></telerik:radbutton>
        </div>
        <div id="divPreview" runat="server"></div>
        
    </form>
    <script type="text/javascript">
        
        function InsertSpan() {
            var oPrompt = radprompt("What is the answer to Life, the Universe and Everything?", "promptCallBackFn", 350, 100, null, "Deep Thought", "42");
            return;
            var editor = $find("<%=editor.ClientID%>");
            editor.pasteHtml(' &nbsp; <field value="TransferNumber">[ رقم الصادر ]</field> &nbsp; ');
        }
        
    </script>
    
</body>
</html>
