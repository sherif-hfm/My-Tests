<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Lat/Lon</title>
    
    <link rel="stylesheet" type="text/css" href="http://serverapi.arcgisonline.com/jsapi/arcgis/1.1/js/dojo/dijit/themes/tundra/tundra.css">
    <script type="text/javascript" src="http://serverapi.arcgisonline.com/jsapi/arcgis/?v=1.1"></script>
    
    <script type="text/javascript">
        dojo.require("esri.map");

        var map;

        function init() {
            map = new esri.Map("map");
            map.addLayer(new esri.layers.ArcGISTiledMapServiceLayer("http://server.arcgisonline.com/ArcGIS/rest/services/ESRI_Imagery_World_2D/MapServer"));
        }

        function addPointToMap(lon, lat) {
            map.graphics.add(
              new esri.Graphic(
                new esri.geometry.Point

                (lon, lat, map.spatialReference),
                new esri.symbol.SimpleMarkerSymbol().setColor(new dojo.Color([255, 0, 0, 0.5]))
              )
            )
        }


        function addPolyToMap(lon, lat) {
            map.graphics.add(
              new esri.Graphic(
                new esri.geometry.Point

                (lon, lat, map.spatialReference),
                new esri.symbol.SimpleMarkerSymbol().setColor(new dojo.Color([255, 0, 0, 0.5]))
              )
            )
        }

        dojo.addOnLoad(init);
    </script>
  </head>
  <body class="tundra">
    longitude <input type="text" id="lon" value="-122.44400024414062" />
    latitude <input type="text" id="lat" value="37.75382995605469" />
    <button onclick="addPointToMap(parseFloat(dojo.byId('lon').value), parseFloat(dojo.byId('lat').value));">Add Point to Map</button>
    <div id="map" style="width:1024px; height:512px; border:1px solid #000;"></div>
  </body>
</html>