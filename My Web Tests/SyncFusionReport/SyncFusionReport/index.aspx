<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SyncFusionReport.index" %>

<%@ Register assembly="Syncfusion.EJ.Web, Version=13.3460.0.18, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" namespace="Syncfusion.JavaScript.Web" tagprefix="ej" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="~/Content/images/favicon.ico">
    <link href="Content/ej/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/ej/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="Content/ej/flat-lime/ej.theme.min.css" rel="stylesheet" />
    <link href="Content/sampleBrowserSite.css" rel="stylesheet" />
    <link href="Content/sampleBrowserSite-responsive.css" rel="stylesheet" />
    <link href="Content/SourceTabFormatter.css" rel="stylesheet" />
	 <link href="Content/diagram/drawingtools/drawingtools.css" rel="stylesheet" />
    <script src='<%= Page.ResolveClientUrl("~/Scripts/jquery-1.11.3.min.js")%>' type="text/javascript"></script>
    <![endif]-->
    <!--[if gte IE 9]><!-->
    <script src='<%= Page.ResolveClientUrl("~/Scripts/jquery-2.1.4.min.js")%>' type="text/javascript"></script>
    <!--<![endif]-->
  
    <script src='<%= Page.ResolveClientUrl("~/Scripts/jsviews.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/jsrender.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/jquery.easing-1.3.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/jquery.globalize.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/cultures/globalize.culture.en-US.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/cultures/globalize.culture.fr-FR.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/cultures/globalize.culture.es-ES.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.web.all.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.webform.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/jsondatachart.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/sampleBrowserSite.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/sampleslist.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/properties.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/rgbcolor.js") %>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/canvg.js") %>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/Scripts/ZeroClipboard.js")%>' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <ej:ReportViewer ID="rv1" runat="server">
        </ej:ReportViewer>
    
    </div>
    </form>
</body>
</html>
