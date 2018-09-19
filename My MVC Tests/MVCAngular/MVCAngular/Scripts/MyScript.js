/// <reference path="angular.js" />
(function () {
    var app = angular.module("MyModule", ["ngRoute"]);

    var config = function ($routeProvider) {

    }

    app.config(config);

    var myController = function ($scope, $http) {
        //$scope.message = "Hello, World!";
        $http.get("/Home/GetData")
        .success(function (data) {
            $scope.persons = data;
});
    };
    myController.$inject = ["$scope", "$http"];
    app.controller("myController", myController);
}());