$(document).ready(function () {
    $('#jqui button').button().click(function (e) {
        var scope = angular.element(angularRegion).scope();
        //scope.$apply('handleClick()');
        scope.$apply(scope.handleClick(this));
        //scope.handleClick();
        //scope.$apply();
    });
});

app = angular.module("ngBasics", [])
.controller("simpleCtrl", function ($scope) {
    $scope.buttonEnabled = true;
    $scope.clickCounter = 0;
    $scope.handleClick = function (sender) {
        console.log('handleClick ' + sender);
        $scope.clickCounter++;
    }

    $scope.$watch('buttonEnabled', function (newValue) {
        $('#jqui button').button({
            disabled: !newValue
        });
    });
});