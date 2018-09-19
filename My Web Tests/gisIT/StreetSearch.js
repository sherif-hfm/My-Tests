var map;
var graphicsLayer;
require(["esri/map", "esri/layers/ArcGISTiledMapServiceLayer", "esri/tasks/query", "esri/tasks/QueryTask", "dojo/data/ItemFileReadStore", "dijit/form/FilteringSelect", "esri/layers/GraphicsLayer",
    "esri/symbols/SimpleFillSymbol", "esri/graphic",
"dojo/dom", "dojo/on", "dojo/domReady!"],
  function init(Map, Tiled, Query, QueryTask,
      itemFileReadStore, FilteringSelect, GraphicsLayer,
      SimpleFillSymbol, Graphic, dom, on) {

      map = new Map("mapDiv");
      var basemap = new Tiled("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer");
      map.addLayer(basemap);

      graphicsLayer = new GraphicsLayer({ id: "myGraphicsLayer" });
      map.addLayer(graphicsLayer);

      var queryTask, query;
      var StreetsList;
      var TotalStreetsResults;
      var StreetCount;

      LoadAllMuncs();
      on(dom.byId("execute"), "click", execute);

      function LoadAllMuncs() {

          queryTask = new QueryTask("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer/19");

          query = new Query();
          query.returnGeometry = true;
          query.outFields = ["MUNICIPALITYCODE", "MUNICIPALITYANAME"];
          query.where = "MUNICIPALITYCODE < 16";
          queryTask.execute(query, showResultsMun);
          dojo.byId('cmbMunc').onchange = function () {
              MuncComboChange(dojo.byId('cmbMunc'));
          };
      }

      function LoadDistricts(MuncCode) {

          queryTask = new QueryTask("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer/17");
          query = new Query();
          query.returnGeometry = true;
          query.outFields = ["NEIGHBORHCODE", "NEIGHBORHANAME"];
          query.where = "MUNICIPALITYCODE =" + MuncCode;
          queryTask.execute(query, showResultsDist);
          dojo.byId('cmbDist').onchange = function () {
              distComboChange(dojo.byId('cmbDist'));
          };
      }

      function LoadStreet(DistCode) {
          //ShowPleaseWait();
          queryTask = new QueryTask("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer/2");
          query = new Query();
          query.returnGeometry = true;
          query.outFields = ["TRANS.StreetUpdate.STREETID", "TRANS.STREETCENTERLINESNAME.STREETANAME"];
          query.where = "TRANS.StreetUpdate.DISTRICT = '" + DistCode + "'";
          queryTask.execute(query, showResultsStreet);
          dojo.byId('cmbStreet').onchange = function () {
              streetComboChange(dojo.byId('cmbStreet'));
          };
      }


      function showResultsMun(results) {
          var munArray = new Array();
          for (var i = 0, il = results.features.length; i < il; i++) {
              var featureAttributes = results.features[i].attributes;

              if (featureAttributes.MUNICIPALITYANAME) {
                  var option = document.createElement("option");
                  option.text = featureAttributes.MUNICIPALITYANAME;
                  munArray[i] = featureAttributes.MUNICIPALITYANAME;
                  option.Value = results.features[i];
                  dojo.byId('cmbMunc').options.add(option);
              }
          }

          var sortedArray = munArray.sort();
          var options = dojo.byId('cmbMunc').options;
          dojo.byId('cmbMunc').options = null;

          var optionSelect = document.createElement("option");
          optionSelect.text = "-- إختر --";
          optionSelect.Value = null;
          dojo.byId('cmbMunc').options.add(optionSelect);
          for (var k = 0; k < sortedArray.length; k++) {
              for (var j = 0; j < options.length; j++) {
                  if (sortedArray[k] == options[j].text) {
                      dojo.byId('cmbMunc').options.add(options[j]);
                  }
              }
          }
          HidePleaseWait();
          SelectChooseOption(document.getElementById('cmbMunc'));
      }

      function showResultsDist(results) {
          var disArray = new Array();
          ClearCombo(dojo.byId('cmbDist'));
          for (var i = 0, il = results.features.length; i < il; i++) {
              var featureAttributes = results.features[i].attributes;

              if (featureAttributes.NEIGHBORHANAME) {
                  var option = document.createElement("option");
                  option.text = featureAttributes.NEIGHBORHANAME;
                  disArray[i] = featureAttributes.NEIGHBORHANAME;
                  option.Value = results.features[i];
                  dojo.byId('cmbDist').options.add(option);
              }
          }

          var sortedArray = disArray.sort();
          var options = dojo.byId('cmbDist').options;
          dojo.byId('cmbDist').options = null;

          var optionSelect = document.createElement("option");
          optionSelect.text = "-- إختر --";
          optionSelect.Value = null;
          dojo.byId('cmbDist').options.add(optionSelect);

          for (var k = 0; k < sortedArray.length; k++) {
              for (var j = 0; j < options.length; j++) {
                  if (sortedArray[k] == options[j].text) {
                      dojo.byId('cmbDist').options.add(options[j]);
                  }
              }
          }
          HidePleaseWait();
          SelectChooseOption(document.getElementById('cmbDist'));
      }

      function showResultsStreet(results) {
          var strArray = new Array();
          ClearCombo(dojo.byId('cmbStreet'));
          StreetsList = [];
          TotalStreetsResults = results.features;
          StreetCount = 0;
          for (var i = 0, il = results.features.length; i < il; i++) {
              var featureAttributes = results.features[i].attributes;

              if (featureAttributes["TRANS.STREETCENTERLINESNAME.STREETANAME"]) {
                  if (ISNewStreet(featureAttributes["TRANS.STREETCENTERLINESNAME.STREETANAME"])) {
                      StreetsList[StreetCount] = featureAttributes["TRANS.STREETCENTERLINESNAME.STREETANAME"];
                      var option = document.createElement("option");
                      option.text = featureAttributes["TRANS.STREETCENTERLINESNAME.STREETANAME"];
                      strArray[i] = featureAttributes["TRANS.STREETCENTERLINESNAME.STREETANAME"];
                      option.Value = results.features[i];
                      dojo.byId('cmbStreet').options.add(option);
                      StreetCount++;
                  }
              }
          }

          var sortedArray = strArray.sort();
          var options = dojo.byId('cmbStreet').options;
          dojo.byId('cmbStreet').options = null;

          var optionSelect = document.createElement("option");
          optionSelect.text = "-- إختر --";
          optionSelect.Value = null;
          dojo.byId('cmbStreet').options.add(optionSelect);

          for (var k = 0; k < sortedArray.length; k++) {
              for (var j = 0; j < options.length; j++) {
                  if (sortedArray[k] == options[j].text) {
                      dojo.byId('cmbStreet').options.add(options[j]);
                  }
              }
          }
          HidePleaseWait();
          SelectChooseOption(document.getElementById('cmbStreet'));
      }

      function ISNewStreet(streetName) {
          if (!StreetsList || !StreetsList.length || StreetsList.length == 0) {
              return true;
          }
          for (var i = 0, il = StreetsList.length; i < il; i++) {
              if (StreetsList[i] == streetName) {
                  return false;
              }
          }
          return true;
      }

      function MuncComboChange(dropdown) {
          var myindex = dropdown.selectedIndex;
          var SelValue = dropdown.options[myindex].Value;
          if (SelValue) {

              map.graphics.clear();
              HighlightPolygonSymbol(SelValue);
              //Add graphic to the map graphics layer.
              map.graphics.add(SelValue);

              var OBJECTIDExtent = SelValue.geometry.getExtent();
              map.setExtent(OBJECTIDExtent);
          
          }
          LoadDistricts(dropdown.options[myindex].Value.attributes.MUNICIPALITYCODE);
      }

      function distComboChange(dropdown) {
          var myindex = dropdown.selectedIndex;
          var SelValue = dropdown.options[myindex].Value;
          if (SelValue) {

              map.graphics.clear();
              HighlightPolygonSymbol(SelValue);
              //Add graphic to the map graphics layer.
              map.graphics.add(SelValue);

              var OBJECTIDExtent = SelValue.geometry.getExtent();
              map.setExtent(OBJECTIDExtent);
          }
          LoadStreet(dropdown.options[myindex].Value.attributes.NEIGHBORHCODE);
      }

      function streetComboChange(dropdown) {
          map.graphics.clear();
          var myindex = dropdown.selectedIndex;
          var SelValue = dropdown.options[myindex].Value;
          var features = [];
          var count = 0;
          if (SelValue) {
              for (var i = 0, il = TotalStreetsResults.length; i < il; i++) {

                  var featureAttributes = TotalStreetsResults[i].attributes;

                  if (featureAttributes["TRANS.STREETCENTERLINESNAME.STREETANAME"] == dropdown.options[myindex].text) {

                      HighlightLineSymbol(TotalStreetsResults[i]);
                      //Add graphic to the map graphics layer.
                      map.graphics.add(TotalStreetsResults[i]);
                      features[count] = TotalStreetsResults[i];
                      count++;
                  }
              }
              var extent = esri.graphicsExtent(features);

              map.setExtent(extent, true);
          
          
              alert(extent.Tostring());
            

              document.getElementById("<%=HiddenField1.ClientID %>").value = extent;
              HideMainMenu();
          }
      }

      function HighlightPolygonSymbol(Graphic) {

          var symbol = new esri.symbol.SimpleFillSymbol().setColor(new dojo.Color([235, 150, 237, 0.35]));

          Graphic.setSymbol(symbol);
      }

      function HighlightLineSymbol(Graphic) {

          var symbol = new esri.symbol.SimpleLineSymbol(esri.symbol.SimpleLineSymbol.STYLE_DASH,
              new dojo.Color([255, 0, 0]), 3);

          Graphic.setSymbol(symbol);
      }

      function ClearCombo(combo) {
          var length = combo.options.length;
          if (length > 1) {
              for (i = length; i >= 0; i--) {
                  combo.options[i] = null;
              }
          }
      }
  });

