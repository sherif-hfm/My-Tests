<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TelerikScheduler.index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .timeSlot{
            background-color:white !important;
        }
        .rsSunCol
        {
background-color:white;
        }
        .RadScheduler_Default .rsSunCol1{
            background-color:#ffffff !important;
        }
    </style>
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


    
        <telerik:RadScheduler RenderMode="Lightweight" runat="server" ID="RadScheduler1"  OnClientTimeSlotClick = "OnClientTimeSlotClick" width="1000px"
            
            DataKeyField="ID" DataSubjectField="Subject" DataStartField="Start" DataEndField="End"
            DataRecurrenceField="RecurrenceRule" DataRecurrenceParentKeyField="RecurrenceParentId"
            DataReminderField="Reminder" MinutesPerRow="5" NumberOfHoveredRows="1" OnAppointmentClick="RadScheduler1_AppointmentClick" TimeLabelRowSpan="1" AppointmentStyleMode="Default" 
            OnAppointmentCommand="RadScheduler1_AppointmentCommand" OnAppointmentContextMenuItemClicked="RadScheduler1_AppointmentContextMenuItemClicked" 
            OnAppointmentCreated="RadScheduler1_AppointmentCreated" OnAppointmentContextMenuItemClicking="RadScheduler1_AppointmentContextMenuItemClicking" 
            OnAppointmentInsert="RadScheduler1_AppointmentInsert" OnNavigationCommand="RadScheduler1_NavigationCommand" OnTimeSlotContextMenuItemClicked="RadScheduler1_TimeSlotContextMenuItemClicked" 
            OnTimeSlotCreated="RadScheduler1_TimeSlotCreated" ShowNavigationPane="False" StartEditingInAdvancedForm="False" SelectedDate="2016-06-05" ShowAllDayRow="False" ShowFooter="False"
             WorkDayEndTime="13:00:00" WorkDayStartTime="07:30:00" Culture="ar-SA" SelectedView="MultiDayView" LastDayOfWeek="Thursday" RowHeaderWidth="100px" RowHeight="50px" ShowHeader="False"
             Skin="Windows7">
<ExportSettings>
<Pdf PageTopMargin="1in" PageBottomMargin="1in" PageLeftMargin="1in" PageRightMargin="1in"></Pdf>
</ExportSettings>

            <AdvancedForm Modal="true"></AdvancedForm>
            <TimelineView UserSelectable="false" columnheaderdateformat="hh:mm tt" numberofslots="24" slotduration="00:05:00" starttime="07:30:00"></TimelineView>
             <weekview userselectable="False" />
             <dayview dayendtime="13:00:00" daystarttime="07:30:00" GroupBy="User" ReadOnly="True" UserSelectable="False" />
             <multidayview dayendtime="13:30:00" daystarttime="07:30:00" ColumnHeaderDateFormat="ddd, d MMM" />
             <monthview userselectable="False" />
            <AppointmentContextMenuSettings EnableDefault="true"></AppointmentContextMenuSettings>
            <Reminders Enabled="true"></Reminders>
             <InlineInsertTemplate>
                <div id="InlineInsertTemplate" class="rsCustomAppointmentContainer technical">
                    <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert">حجز موعد </asp:LinkButton>
                </div>
            </InlineInsertTemplate>
            <%-- <ResourceHeaderTemplate>
                    <asp:Panel ID="ResourceImageWrapper" runat="server" CssClass="ResCustomClass">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Text") %>'></asp:Label>
                    </asp:Panel>
                </ResourceHeaderTemplate>--%>
        </telerik:RadScheduler>
    

         
        <br />
        <asp:TextBox ID="txtData" runat="server" Width="500px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    </form>
    <script>
        function OnClientTimeSlotClick(sender, eventArgs) {
            alert(eventArgs.get_time());
        }
    </script>
</body>
</html>
