/// <reference path="angular.min.js" />
(function () {

    var app2 = angular.module("ngBasics.Example2", []);

    app2.config(function () {
        console.log("app2 module config: " );
    });
    app2.run(function (startTime) {
        console.log("app2 module run: " + startTime);
    });

    var now = new Date();
    app2.value("nowValue", now);

    app2.controller("FormTestCtrl", function ($scope) {
        console.log("FormTestCtrl");
        $scope.SelectedValue = "1";
        this.GetData = function () {
            console.log($scope.SelectedValue);
        };
    });

    app2.controller("dayCtrl", function ($scope, days) {
        $scope.day = days.today;
    });

    app2.controller("tomorrowCtrl", function ($scope, days) {
        $scope.day = days.tomorrow;
    });

    app2.directive("highlight", function ($filter) {
        var dayFilter = $filter("dayName");
        return function (scope, element, attrs) {
            if (dayFilter(scope.day) == attrs["highlight"]) {
                element.css("color", "red");
            }
        }
    });

    app2.filter("dayName", function () {
        var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday",
        "Thursday", "Friday", "Saturday"];
        return function (input) {
            return angular.isNumber(input) ? dayNames[input] : input;
        };
    });

    app2.service("days", function (nowValue) {
        this.today = nowValue.getDay();
        this.tomorrow = this.today + 1;
    });
    
}());