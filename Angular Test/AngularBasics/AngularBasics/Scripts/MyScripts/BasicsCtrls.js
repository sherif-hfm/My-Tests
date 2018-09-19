/// <reference path="angular.min.js" />

(function () {
    app = angular.module("ngBasics");
    app.controller("StoreController", ['$http', function ($http) {
        var store = this;
        store.Products = [];
        $http.get("/Home/GetProductData")
        .success(function (data) {
            console.log("success");
            console.log(data);
            store.Products = data;
        });
        this.GetCommentCount = function (_prod) {
            return _prod.reviews.length;
        };
    }]);

    app.controller("PanelController", function () {
        this.tab = 1;
        this.selectTab = function (setTab) {
            this.tab = setTab;
        }
        this.IsSelected = function (checkTab) {
            return this.tab === checkTab;
        }
    });
}());
   
