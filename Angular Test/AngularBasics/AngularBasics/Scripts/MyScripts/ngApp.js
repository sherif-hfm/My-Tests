/// <reference path="angular.min.js" />

(function () {
    var app = angular.module("ngBasics", []);
    //var app = angular.module("ngBasics", ["ngBasics.Example2"]);

    app.constant("startTime", new Date().toLocaleTimeString());
    app.config(function (startTime) {
        console.log("app module config: " + startTime);
    });
    app.run(function (startTime) {
        console.log("app module run: " + startTime);
    });

}());