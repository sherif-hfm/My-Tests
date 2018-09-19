<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UmmAlQuraCalendar.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="buttonPicker" type="text" size="10" class="is-datepick" />
    <div  style="display:none">
        <input id="btnshow" type="button" value="button" />
    </div>
    <script type="text/javascript">
        $(document).ready(function () {

            var myCalendar = $.calendars.instance('ummalqura', 'ar');
            $('#buttonPicker').calendarsPicker({
                calendar: myCalendar,
                showTrigger: '#btnshow'
            });

        });

    </script>
</asp:Content>
