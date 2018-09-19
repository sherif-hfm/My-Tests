(function () {
    app = angular.module("ngBasics");
    app.controller("simpleCtrl", function ($scope) {
        $scope.cities = ["London", "New York", "Paris"];
        $scope.city = "London";
        $scope.getCountry = function (city) {
            switch (city) {
                case "London":
                    return "UK";
                case "New York":
                    return "USA";
            }
        }
    });

    app.service("ZipCodes", function($rootScope) {
        return {
            setZipCode: function(type, zip) {
                this[type] = zip;
                $rootScope.$broadcast("zipCodeUpdated", {
                    type: type, zipCode: zip
                });
            }
        }
    });
    app.controller("simple2Ctrl", function ($scope, $rootScope, ZipCodes) {
        
        $scope.$on("zipCodeUpdated", function (event, args) {
            $scope[args.type] = args.zipCode;
        });

        $scope.setAddress = function (type, zip) {
            //$rootScope.$broadcast("zipCodeUpdated", {type: type, zipCode: zip});
            ZipCodes.setZipCode(type, zip);
            console.log("Type: " + type + " " + zip);
        }
        $scope.copyAddress = function () {
            $scope.shippingZip = $scope.billingZip;
        }
    });

}());

