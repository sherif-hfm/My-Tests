<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DataPaging.index" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat="server">
    <title>Data Paging</title>
   
</head>
<body>
    <form id="form1" runat="server">
        <telerik:radscriptmanager runat="server" id="RadScriptManager1" />
        <telerik:radgrid runat="server" id="grd"></telerik:radgrid>
        <div>
            <div>
                <telerik:raddatapager id="RadDataPager1" runat="server" onpageindexchanged="RadDataPager1_PageIndexChanged" ontotalrowcountrequest="RadDataPager1_TotalRowCountRequest" pagesize="3" >
                    <Fields>
                        <telerik:RadDataPagerButtonField FieldType="FirstPrev"></telerik:RadDataPagerButtonField>
                        <telerik:RadDataPagerButtonField FieldType="Numeric" PageButtonCount="16"></telerik:RadDataPagerButtonField>
                        <telerik:RadDataPagerButtonField FieldType="NextLast"></telerik:RadDataPagerButtonField>
                    </Fields>
                </telerik:raddatapager>
            </div>
        </div>
    </form>
</body>
</html>
