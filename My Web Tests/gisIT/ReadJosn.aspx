<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadJosn.aspx.cs" Inherits="ReadJosn" %>

<!doctype html>
<html>
<head>
    <title>...</title>
    <link rel="stylesheet" type="text/css" href="http://serverapi.arcgisonline.com/jsapi/arcgis/2.2/js/dojo/dijit/themes/claro/claro.css">
    <script type="text/javascript" src="http://serverapi.arcgisonline.com/jsapi/arcgis/?v=2.2"></script>
    <script type="text/javascript" language="Javascript">
        dojo.require("esri.map");
        dojo.require("esri.layers.FeatureLayer");
        dojo.require("esri.graphic")
        var map;
        function init( ) {
            //var startExtent = new esri.geometry.Extent({ "xmin": -12505511, "ymin": 2230016, "xmax": -3699965, "ymax": 8100380, "spatialReference": { "wkid": 102100 } });
            map = new esri.Map("mapDiv");
            //create and add new layer
            var layer = new esri.layers.ArcGISTiledMapServiceLayer("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer");
            map.addLayer(layer);

            var jsonFS =
              { "geometry": { "rings": [[[643551.2074705824, 2779476.4612986147], [645998.6081987172, 2780667.0886798697], [650827.2636893615, 2780468.6507829935], [671134.0751363178, 2772597.2808735874], [676028.8765925873, 2765122.786757932], [671266.3670675682, 2756457.6652610227], [659360.0932550207, 2749975.3606297467], [650364.2419299847, 2750041.5065953718], [640905.3688455719, 2753481.0968078854], [631975.6634861612, 2760757.1530266646], [628932.949067399, 2768694.6689016963], [629792.8466205274, 2775110.8275673473], [635679.8375611759, 2779013.439539238], [642559.0179862034, 2779608.7532298653], [643551.2074705824, 2779476.4612986147]]], "spatialReference": { "wkid": 32638, "latestWkid": 32638 } }, "symbol": { "color": [0, 0, 0, 64], "outline": { "color": [0, 0, 0, 255], "width": 1, "type": "esriSLS", "style": "esriSLSSolid" }, "type": "esriSFS", "style": "esriSFSSolid" } }
            ;

         

            
            alert("جاري التحميل");

            var graphic = new esri.Graphic(jsonFS);

           // -add in map
           map.graphics.add(graphic);
         
           


           




        }
        dojo.ready(init);
    </script>
</head>
<body class="claro">
    <form id="ID" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div id="mapDiv" style="width: 900px; height: 600px; border: 1px solid #000;"></div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button1" runat="server" Text="Button"  OnClientClick="init()"/>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
