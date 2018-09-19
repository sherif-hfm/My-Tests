﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Draw.aspx.cs" Inherits="Draw" %>
<!DOCTYPE html>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,user-scalable=no">
    <!--The viewport meta tag is used to improve the presentation and behavior of the samples 
      on iOS devices-->
    <meta name="viewport" content="initial-scale=1, maximum-scale=1,user-scalable=no">
    <title>Maps Toolbar</title>
    
    <link rel="stylesheet" href="http://js.arcgis.com/3.14/dijit/themes/nihilo/nihilo.css">
    <link rel="stylesheet" href="http://js.arcgis.com/3.14/esri/css/esri.css">
    <style>
      html, body, #mainWindow {
        font-family: sans-serif; 
        height: 100%; 
        width: 100%; 
      }
      html, body {
        margin: 0; 
        padding: 0;
      }
      #header {
        height: 80px; 
        overflow: auto;
        padding: 0.5em;
      }
    </style>
    
    <script src="http://js.arcgis.com/3.14/"></script>
    <script>
        var map, toolbar, symbol, geomTask;

        require([
          "esri/map",
          "esri/toolbars/draw",
          "esri/graphic",
          "esri/layers/ArcGISTiledMapServiceLayer",
          
          "esri/symbols/SimpleMarkerSymbol",
          "esri/symbols/SimpleLineSymbol",
          "esri/symbols/SimpleFillSymbol",

          "dojo/parser", "dijit/registry",

          "dijit/layout/BorderContainer", "dijit/layout/ContentPane",
          "dijit/form/Button", "dijit/WidgetSet", "dojo/domReady!"
        ], function (
          Map, Draw, Graphic,Tiled,
          SimpleMarkerSymbol, SimpleLineSymbol, SimpleFillSymbol,
          parser, registry
        ) {
            parser.parse();


            map = new Map("map");
            var basemap = new Tiled("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer");
            map.addLayer(basemap);

         


            map.on("load", createToolbar);

            // loop through all dijits, connect onClick event
            // listeners for buttons to activate drawing tools
            registry.forEach(function (d) {
                // d is a reference to a dijit
                // could be a layout container or a button
                if (d.declaredClass === "dijit.form.Button") {
                    d.on("click", activateTool);
                }
            });

            function activateTool() {
                var tool = this.label.toUpperCase().replace(/ /g, "_");
                toolbar.activate(Draw[tool]);
                map.hideZoomSlider();
            }

            function createToolbar(themap) {
                toolbar = new Draw(map);
                toolbar.on("draw-end", addToMap);
            }

            function addToMap(evt) {
                var symbol;
                toolbar.deactivate();
                map.showZoomSlider();
                switch (evt.geometry.type) {
                    case "point":
                    case "multipoint":
                        symbol = new SimpleMarkerSymbol();
                        break;
                    case "polyline":
                        symbol = new SimpleLineSymbol();
                        break;
                    default:
                        symbol = new SimpleFillSymbol();
                        break;
                }
                var graphic = new Graphic(evt.geometry, symbol);
                map.graphics.add(graphic);
                //var e = dojo.JSON.stringify(graphic) غلط
               
                var sss = dojo.toJson(graphic.toJson());
               
                alert(sss);
            }
        });
    </script>
  </head>
  <body class="nihilo">

  <div id="mainWindow" data-dojo-type="dijit/layout/BorderContainer" data-dojo-props="design:'headline'">
    <div id="header" data-dojo-type="dijit/layout/ContentPane" data-dojo-props="region:'top'">
      <span>Draw:<br /></span>
      
      <button data-dojo-type="dijit/form/Button">Multi Point</button>
     
      <button data-dojo-type="dijit/form/Button">Polyline</button>
      <button data-dojo-type="dijit/form/Button">Polygon</button>
      <button data-dojo-type="dijit/form/Button">Freehand Polyline</button>
      <button data-dojo-type="dijit/form/Button">Freehand Polygon</button>
      <!--The Arrow,Triangle,Circle and Ellipse types all draw with the polygon symbol-->
      <button data-dojo-type="dijit/form/Button">Arrow</button>
   <%--   <button data-dojo-type="dijit/form/Button">Triangle</button>
      <button data-dojo-type="dijit/form/Button">Circle</button>
      <button data-dojo-type="dijit/form/Button">Ellipse</button>--%>
    </div>
    <div id="map" data-dojo-type="dijit/layout/ContentPane" data-dojo-props="region:'center'"></div>
  </div>

  </body>
</html>
