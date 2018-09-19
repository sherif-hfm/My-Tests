﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test11.aspx.cs" Inherits="test11" %>

<!DOCTYPE html>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <!--The viewport meta tag is used to improve the presentation and behavior of the samples 
      on iOS devices-->
    <meta name="viewport" content="initial-scale=1, maximum-scale=1,user-scalable=no">
    <title>Simplify a polygon</title>

    <link rel="stylesheet" href="http://js.arcgis.com/3.14/dijit/themes/claro/claro.css">
    <link rel="stylesheet" href="http://js.arcgis.com/3.14/esri/css/esri.css"> 

    <script src="http://js.arcgis.com/3.14/"></script>
    <script>
        dojo.require("esri.map");
        dojo.require("esri.tasks.geometry");
        dojo.require("esri.geometry");

        var map = null;
        var gsvc = null;
        var qtask = null;
        var polygonGraphic = null;
        var queryGraphic = null;

        function initialize() {
            map = new esri.Map("map", {
                basemap: "streets",
                center: [-83.273, 42.572],
                zoom: 15
            });
            console.log("created map");
            dojo.connect(map, "onLoad", drawPolygon);

            gsvc = new esri.tasks.GeometryService("http://tasks.arcgisonline.com/ArcGIS/rest/services/Geometry/GeometryServer");
            qtask = new esri.tasks.QueryTask("http://sampleserver3.arcgisonline.com/ArcGIS/rest/services/BloomfieldHillsMichigan/Parcels/MapServer/2");
        }

        function drawPolygon() {
            console.log("draw poly");
            var latOffset, lonOffset, center, lat, lon, points;

            var center = map.extent.getCenter();
            var lat = center.y;
            var lon = center.x + 500;

            // Create a Green Polygon
            var latOffset = 500;
            var lonOffset = 500;
            var points = [
              new esri.geometry.Point(lon - lonOffset, lat, map.spatialReference),
              new esri.geometry.Point(lon, lat + latOffset, map.spatialReference),
              new esri.geometry.Point(lon + lonOffset, lat, map.spatialReference),
              new esri.geometry.Point(lon, lat - latOffset, map.spatialReference),
              new esri.geometry.Point(lon - lonOffset, lat, map.spatialReference),
              new esri.geometry.Point(lon - 2 * lonOffset, lat + latOffset, map.spatialReference),
              new esri.geometry.Point(lon - 3 * lonOffset, lat, map.spatialReference),
              new esri.geometry.Point(lon - 2 * lonOffset, lat - latOffset, map.spatialReference),
              new esri.geometry.Point(lon - 1.5 * lonOffset, lat + latOffset, map.spatialReference),
              new esri.geometry.Point(lon - lonOffset, lat, map.spatialReference)
            ];
            var polygon = new esri.geometry.Polygon();
            polygon.addRing(points);
            polygon.spatialReference = map.spatialReference;

            console.log("created poly geom");

            // Add the polygon to map
            var symbol = new esri.symbol.SimpleFillSymbol().setStyle(esri.symbol.SimpleFillSymbol.STYLE_SOLID);
            polygonGraphic = new esri.Graphic(polygon, symbol, { keeper: true });
            var polyLayer = new esri.layers.GraphicsLayer({ id: "poly" });
            map.addLayer(polyLayer);
            polyLayer.add(polygonGraphic);
            console.log("added poly graphic");
        }

        function doSimplify() {
            //simplify the polygon if self-intersecting
            if (esri.geometry.polygonSelfIntersecting(polygonGraphic.geometry)) {
                console.log("doing simplify");
                gsvc.simplify([polygonGraphic.geometry], simplifyCallback);
            }
        }

        function simplifyCallback(geometries) {
            alert("Number of Rings returned by Simplify operation = " + geometries[0].rings.length);
            polygonGraphic.setGeometry(geometries[0]);
            doQuery(polygonGraphic); // select a ring to do query
        }

        function doQuery(polygonGraphic) {
            map.graphics.clear();

            var query = new esri.tasks.Query();
            //query.spatialRelationship = esri.tasks.Query.SPATIAL_REL_INTERSECTS;
            query.spatialRelationship = esri.tasks.Query.SPATIAL_REL_CONTAINS;
            query.geometry = polygonGraphic.geometry;
            query.returnGeometry = true;
            qtask.execute(query, queryCallback);
        }

        function queryCallback(featureSet) {
            var symbol = new esri.symbol.SimpleFillSymbol(esri.symbol.SimpleFillSymbol.STYLE_SOLID, new esri.symbol.SimpleLineSymbol(esri.symbol.SimpleLineSymbol.STYLE_SOLID, new dojo.Color([0, 0, 255, 0.65]), 2), new dojo.Color([0, 0, 255, 0.35]));
            var features = featureSet.features;
            dojo.forEach(features, function (f) {
                f.setSymbol(symbol);
                map.graphics.add(f);
            });
        }

        dojo.ready(initialize);
  </script>
</head>

<body class="claro">
  Many spatial operations require topologically correct geometry.
  <br>
  <input type="button" value="Simplify the polygon and Do a Query with simplified polygon" onclick="doSimplify();" />
  <br>If you try to use the self-intersecting geometry above without simplifying it you will get incorrect results.
  <br>
  <input type="button" value="Execute query task without simplifying polygon" onclick="doQuery(polygonGraphic);" />
  <div id="map" style="width:600px; height:400px; border:1px solid #000;"></div>
</body>
</html>
