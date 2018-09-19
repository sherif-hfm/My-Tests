<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <!--The viewport meta tag is used to improve the presentation and behavior of the samples 
      on iOS devices-->
    <meta name="viewport" content="initial-scale=1, maximum-scale=1,user-scalable=no">
    <title>Create Map and add a dynamic layer</title>
    <link rel="stylesheet" href="http://js.arcgis.com/3.14/esri/css/esri.css" />
    <style>
        html, body, #mapDiv {
            padding: 0;
            margin: 0;
            height: 100%;
        }
    </style>
    <script src="http://js.arcgis.com/3.14/"></script>
    <script>
        var map;
        require([
          "esri/map",
          "esri/layers/ArcGISDynamicMapServiceLayer"],
          function (Map, ArcGISDynamicMapServiceLayer)
          {
            map = new Map("mapDiv");
            var dynamicMapServiceLayer = new ArcGISDynamicMapServiceLayer(
                "http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer"
          );
            map.addLayer(dynamicMapServiceLayer);
        });
    </script>
</head>
<body>
    <div id="mapDiv"></div>
</body>
</html>
