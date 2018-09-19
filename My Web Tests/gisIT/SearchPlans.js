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

      LoadAllPlans();
      on(dom.byId("execute"), "click", execute);

      function LoadAllPlans() {

          queryTask = new QueryTask("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer/14");

          query = new Query();
          query.returnGeometry = true;
          query.outFields = ["GIS.Plans.PLANID", "GIS.PLANPRIMARYINFO.PLANNO", "GIS.PLANPRIMARYINFO.PLANVERSION"];
          query.where = "1=1";
          queryTask.execute(query, showResultsPlans);
          dojo.byId('cmbPlans').onchange = function () {
              PlansComboChange(dojo.byId('cmbPlans'));
          };
      }

      function LoadParcels(PlanId) {

          queryTask = new QueryTask("http://eservices.alriyadh.gov.sa:7070/wariyadhgeomap/rest/services/riyadhgeomap/RiyadhBaseMap/MapServer/9");

          query = new Query();
          query.returnGeometry = true;
          query.outFields = ["PARCELID", "PARCELNO", "PLANID", "PLANBLOCKID", "PLANNO", "DISTRICT"];
          query.where = "PLANID =" + PlanId;
          queryTask.execute(query, showResultsParcels);
          dojo.byId('cmbVersion').onchange = function () {
              parcelComboChange(dojo.byId('cmbVersion'));
          };
      }


      function showResultsPlans(results) {
          var planArray = new Array();
          for (var i = 0, il = results.features.length; i < il; i++) {

              var featureAttributes = results.features[i].attributes;

              if (featureAttributes["GIS.PLANPRIMARYINFO.PLANNO"] && featureAttributes["GIS.PLANPRIMARYINFO.PLANNO"] != "0") {
                  var option = document.createElement("option");
                  if (!featureAttributes["GIS.PLANPRIMARYINFO.PLANVERSION"] || featureAttributes["GIS.PLANPRIMARYINFO.PLANVERSION"] == "0") {
                      option.text = featureAttributes["GIS.PLANPRIMARYINFO.PLANNO"];
                  } else {
                      option.text = featureAttributes["GIS.PLANPRIMARYINFO.PLANNO"] + "(" + featureAttributes["GIS.PLANPRIMARYINFO.PLANVERSION"] + ")";
                  }
                  planArray[i] = option.text;
                  option.Value = results.features[i];
                  dojo.byId('cmbPlans').options.add(option);
              }
          }

          var sortedArray = planArray.sort();
          var options = dojo.byId('cmbPlans').options;
          dojo.byId('cmbPlans').options = null;

          var optionSelect = document.createElement("option");
          optionSelect.text = "-- إختر --";
          optionSelect.Value = null;
          dojo.byId('cmbPlans').options.add(optionSelect);
          for (var k = 0; k < sortedArray.length; k++) {
              for (var j = 0; j < options.length; j++) {
                  if (sortedArray[k] == options[j].text) {
                      dojo.byId('cmbPlans').options.add(options[j]);
                  }
              }
          }
          HidePleaseWait();
          SelectChooseOption(document.getElementById('cmbPlans'));
      }

      function showResultsParcels(results) {
          var disArray = new Array();
          ClearCombo(dojo.byId('cmbVersion'));
          for (var i = 0, il = results.features.length; i < il; i++) {
              var featureAttributes = results.features[i].attributes;

              if (featureAttributes["PARCELNO"]) {
                  var option = document.createElement("option");
                  if (!featureAttributes["PLANBLOCKID"] || featureAttributes["PLANBLOCKID"] == "0") {
                      option.text = featureAttributes["PARCELNO"];
                  } else {
                      option.text = featureAttributes["PARCELNO"] + "(بلوك " + featureAttributes["PLANBLOCKID"] + ")";
                  }
                  disArray[i] = option.text;
                  option.Value = results.features[i];
                  dojo.byId('cmbVersion').options.add(option);
              }
          }

          var sortedArray = disArray.sort();
          var options = dojo.byId('cmbVersion').options;
          dojo.byId('cmbVersion').options = null;

          var optionSelect = document.createElement("option");
          optionSelect.text = "-- إختر --";
          optionSelect.Value = null;
          dojo.byId('cmbVersion').options.add(optionSelect);


          for (var k = 0; k < sortedArray.length; k++) {
              for (var j = 0; j < options.length; j++) {
                  if (sortedArray[k] == options[j].text) {
                      dojo.byId('cmbVersion').options.add(options[j]);
                  }
              }
          }
          HidePleaseWait();
          SelectChooseOption(document.getElementById('cmbVersion'));
      }

      function PlansComboChange(dropdown) {
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
          LoadParcels(dropdown.options[myindex].Value.attributes["GIS.Plans.PLANID"]);
      }

      function parcelComboChange(dropdown) {
          var myindex = dropdown.selectedIndex;
          var SelValue = dropdown.options[myindex].Value;
          if (SelValue) {

              map.graphics.clear();
              HighlightPolygonSymbol(SelValue);
              //Add graphic to the map graphics layer.
              map.graphics.add(SelValue);

              var OBJECTIDExtent = SelValue.geometry.getExtent();
              map.setExtent(OBJECTIDExtent);
              map.infoWindow.hide();
              showInfowWindow("قطعة أرض", PreparePlanNumberText(SelValue), SelValue);

              HideMainMenu();
          }
      }

      function HighlightPolygonSymbol(Graphic) {

          var symbol = new esri.symbol.SimpleFillSymbol().setColor(new dojo.Color([235, 150, 237, 0.35]));

          Graphic.setSymbol(symbol);
      }

      function PreparePlanNumberText(SelValue) {
          return "قطعة رقم: " + SelValue.attributes["PARCELNO"] + "\n" + " رقم المخطط:" + SelValue.attributes["PLANNO"];
      }

      function showInfowWindow(title, content, polygon) {
          map.infoWindow.setTitle(title);
          map.infoWindow.setContent(content);
          var screenPoint = map.toScreen(polygon.geometry.getExtent().getCenter());
          var mapPoint = map.toMap(screenPoint);
          map.infoWindow.show(mapPoint, screenPoint);
          map.setExtent(polygon.geometry.getExtent());
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