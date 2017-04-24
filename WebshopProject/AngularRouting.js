
(function () {
    'use strict';

    angular.module("shopApp", ["ngRoute"]).
        config(function ($routeProvider) {
            $routeProvider
                .when("/", {
                    templateUrl: "/Products/Start"
                })
                .when("/JL", {
                    templateUrl: "/Products/JL"
                })
                .when("/2", {
                    templateUrl: "/Products/Product2"
                })
                .when("/top-2017", {
                    templateUrl: "/Products/Top2017"
                });
        }).
        controller("MainCtrl", function ($scope) {

            $scope.message = "Welcome to the Main Controller!";
        });
    
})();