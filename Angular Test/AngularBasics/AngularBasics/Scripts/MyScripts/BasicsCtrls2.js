(function () {
    app = angular.module("ngBasics");
    app.controller("ReviewController", function ($scope) {
        //this.review = {};
        this.AddReview = function (prod,review) {
            console.log(this.review);
            console.log(prod);
            var newReview = {};
            newReview.comment = review.comment;
            newReview.email = review.email;
            newReview.agree = review.agree;
            prod.reviews.push(newReview);
            //this.review = {};
        };
        this.CanSendCommant = function (_review) {
            //console.log("CanSendCommant");
            if (angular.isDefined(_review))
                return _review.agree;
        }
    });

    var gems = [
        { name: 'Prod1 name', price: 1.30, description: 'Prod1 description', canPurchase: true, soldOut: false, addDate: '01-01-2016', specification: 'Prod1 Specification', reviews: [] },
        { name: 'Prod2 name', price: 2.30, description: 'Prod2 description', canPurchase: true, soldOut: false, addDate: '01-02-2016', specification: 'Prod2 Specification', reviews: [] },
        { name: 'Prod3 name', price: 3.30, description: 'Prod3 description', canPurchase: true, soldOut: false, addDate: '01-03-2016', specification: 'Prod3 Specification', reviews: [] }
    ];

    app.directive('productInfo', function () {
        return {
            restrict: 'E',
            templateUrl: '/Pages/Product.html'
        };
    });
}());