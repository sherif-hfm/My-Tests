<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xy.aspx.cs" Inherits="xy" %>

<!DOCTYPE html>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <!--The viewport meta tag is used to improve the presentation and behavior of the samples 
      on iOS devices-->
    <meta name="viewport" content="initial-scale=1, maximum-scale=1,user-scalable=no">
    <title>Create Map Display Mouse Coordinates</title>
    <link rel="stylesheet" href="http://js.arcgis.com/3.14/esri/css/esri.css">
    
    <script src="http://js.arcgis.com/3.14/"></script>
    <script>
        var map;
        require([
          "esri/map", "esri/geometry/webMercatorUtils", "dojo/dom",
          "dojo/domReady!"
        ], function (
          Map, webMercatorUtils, dom
        ) {
            map = new Map("map", {
                basemap: "streets",
                center: [-47.109, 14.945],
                zoom: 2
            });
            map.on("load", function (

                 Map, ArcGISDynamicMapServiceLayer, ImageParameters) {

                map = new Map("mapDiv", {
                    sliderOrientation: "horizontal"
                });

                var imageParameters = new ImageParameters();
                imageParameters.format = "jpeg"; //set the image type to PNG24, note default is PNG8.

                //Takes a URL to a non cached map service.
                var dynamicMapServiceLayer = new ArcGISDynamicMapServiceLayer("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer", {
                    "opacity": 1,
                    "imageParameters": imageParameters
                })

               
            });
            {
                //after map loads, connect to listen to mouse move & drag events
                map.on("mouse-move", showCoordinates);
                map.on("mouse-drag", showCoordinates);
            });

            function showCoordinates(evt) {
                //the map is in web mercator but display coordinates in geographic (lat, long)
                var mp = webMercatorUtils.webMercatorToGeographic(evt.mapPoint);
                //display mouse coordinates
                dom.byId("info").innerHTML = mp.x.toFixed(3) + ", " + mp.y.toFixed(13);
            }
        })
    </script>
  </head>
  <body>
    <div id="map" style="position:relative; width:900px; height:600px; border:1px solid #000;">
      <span id="info" style="position:absolute; left:15px; bottom:5px; color:#000; z-index:50;"></span>
    </div>
  </body>
</html>