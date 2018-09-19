(function () {
    app = angular.module("ngBasics");
    app.controller("topLevelCtrl", function ($scope) {
        console.log('topLevelCtrl');
        //$scope.dataValue = "Hello, Adam";
        $scope.data = {
            dataValue: "Hello, Adam"
        };
        $scope.reverseText = function () {
            //$scope.dataValue = $scope.dataValue.split("").reverse().join("");
            $scope.data.dataValue = $scope.data.dataValue.split("").reverse().join("");
        }
        $scope.changeCase = function () {
            var result = [];
            //angular.forEach($scope.dataValue.split(""), function (char, index) {
            angular.forEach($scope.data.dataValue.split(""), function (char, index) {
                result.push(index % 2 == 1
                ? char.toString().toUpperCase() : char.toString().toLowerCase());
            });
            //$scope.dataValue = result.join("");
            $scope.data.dataValue = result.join("");
        };
    });

    app.controller("firstChildCtrl", function ($scope) {
        $scope.changeCase = function () {
            //$scope.dataValue = $scope.dataValue.toUpperCase();
            $scope.data.dataValue = $scope.data.dataValue.toUpperCase();
        };
    });

    app.controller("secondChildCtrl", function ($scope) {
        $scope.changeCase = function () {
            //$scope.dataValue = $scope.dataValue.toLowerCase();
            $scope.data.dataValue = $scope.data.dataValue.toLowerCase();
        };
        $scope.shiftFour = function () {
            var result = [];
            //angular.forEach($scope.dataValue.split(""), function (char, index) {
            angular.forEach($scope.data.dataValue.split(""), function (char, index) {
                result.push(index < 4 ? char.toUpperCase() : char);
            });
            //$scope.dataValue = result.join("");
            $scope.data.dataValue = result.join("");
        }
    });

}());