app = angular.module("ngBasics", []);

app.directive("unorderedList1", function () {
    return {
        link: function (scope, element, attrs) {
            var data = scope[attrs["unorderedList"] || attrs["listSource"]];
            var propertyExpression = attrs["listProperty"] || "price | currency";
            if (angular.isArray(data)) {
                var listElem = angular.element("<ul>");
                if (element[0].nodeName == "#comment") {
                    element.parent().append(listElem);
                } else {
                    element.append(listElem);
                }
                for (var i = 0; i < data.length; i++) {
                    var itemElement = angular.element("<li>")
                    .text(scope.$eval(propertyExpression, data[i]));
                    listElem.append(itemElement);
                }
            }
        },
        restrict: "EACM"
    }
});

app.directive("unorderedList", function () {
    return {
        link: function (scope, element, attrs) {
            scope.data = scope[attrs["unorderedList"]];
        },
        restrict: "A",
        template: "<ul><li ng-repeat='item in data'>"
        + "{{item.price | currency}}</li></ul>"
    }
});

app.controller("defaultCtrl", function ($scope) {
    $scope.products = [
    { name: "Apples", category: "Fruit", price: 1.20, expiry: 10 },
    { name: "Bananas", category: "Fruit", price: 2.42, expiry: 7 },
    { name: "Pears", category: "Fruit", price: 2.02, expiry: 6 }
    ];

    $scope.incrementPrices = function () {
        console.log("incrementPrices");
        for (var i = 0; i < $scope.products.length; i++) {
            $scope.products[i].price++;
            console.log($scope.products[i]);
        }
        //$scope.$apply();
    }

});