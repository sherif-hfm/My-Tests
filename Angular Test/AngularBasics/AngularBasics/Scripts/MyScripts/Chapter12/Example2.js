(function () {
    app = angular.module("ngBasics");
    app.controller("defaultCtrl", function ($scope) {
        $scope.addUser = function (userDetails) {
            $scope.message = userDetails.name
            + " (" + userDetails.email + ") (" + userDetails.agreed + ")";
        }
        $scope.message = "Ready";

        $scope.getError = function (error) {
            if (angular.isDefined(error)) {
                if (error.required) {
                    return "Please enter a value";
                } else if (error.email) {
                    return "Please enter a valid email address";
                }
            }
        }
    });
}());