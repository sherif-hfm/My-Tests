var app;
(function () {
    console.log('app Start');
    app = angular.module("APIModule", []);

    app.service("APIService", function ($http) {
        this.saveUserData = function (userData) {
            console.log('srv saveUserData');
            return $http({
                method: 'post',
                data: userData,
                url: 'http://localhost:4010/api/User/SaveUserData'
            });
        }
    });

    app.controller('APIController', function ($scope, APIService) {
        $scope.userName = "";
        $scope.saveUserData= function () {
            console.log('ctrl saveUserData');
            var _userInfo = {};
            _userInfo.UserName = "sherif";
            _userInfo.Password = "123";
            _userInfo.Address = {};
            _userInfo.Address.City = "Sohag";
            _userInfo.Address.Street = "st1";
            var servCall = APIService.saveUserData(_userInfo);
            servCall.then(function (d) {
                $scope.userName = d.data;
            }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.')
            })
        }
    })
})();