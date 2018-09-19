<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>



<%@ Register Src="~/SearchPlans.ascx" TagPrefix="uc1" TagName="SearchPlans" %>
<%@ Register Src="~/MapStreets.ascx" TagPrefix="uc1" TagName="MapStreets" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="http://js.arcgis.com/3.14/"></script>
     <link rel="stylesheet" href="http://js.arcgis.com/3.14/esri/css/esri.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible" />
    <title></title>
    <script>

        var isOpera = !!window.opera || navigator.userAgent.indexOf(' OPR/') >= 0;
        // Opera 8.0+ (UA detection to detect Blink/v8-powered Opera)
        var isFirefox = typeof InstallTrigger !== 'undefined';
        // Firefox 1.0+
        var isSafari = Object.prototype.toString.call(window.HTMLElement).indexOf('Constructor') > 0;
        // At least Safari 3+: "[object HTMLElementConstructor]"
        var isChrome = !!window.chrome && !isOpera;
        // Chrome 1+
        var isIE = /*@cc_on!@*/ false || !!document.documentMode;
        // At least IE6

        window.onerror = function (msg, url, linenumber) {


            return true;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>

        </div>
        <div>
        </div>
        <uc1:MapStreets runat="server" ID="MapStreets" />
       <%-- <uc1:SearchPlans runat="server" ID="SearchPlans" />--%>
        <div id="mapDiv" style="width: 300px; height: 150px">
        </div>

        <%--<div id="mapDiv1" style="width: 500px; height: 300px">
        </div>--%>
    </form>
    <span id="info" style="position: absolute; left: 10px; bottom: 5px; color: #3366CC; z-index: 50; width: 389px; background-color: #00FF00;"></span>
</body>
</html>
