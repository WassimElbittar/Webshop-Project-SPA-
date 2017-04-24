(function () {
    'use strict';

    var shopServ = angular.module("shopService", []);

    shopServ.factory("ShopApi", function ($http) {
        var urlBase = "http://localhost:49217/api";
        var ShopApi = {};

        ShopApi.getCart = function () {
            return $http.get(urlBase + "/Cart");
        };

        ShopApi.addToCart = function (movie) {
            return $http.post(urlBase + "/Cart/", movie);
        };

        return ShopApi;
    });

    var shopA = angular.module("shopApp", ["ngRoute", "shopService"]);

    shopA.config(function ($routeProvider) {
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
    });

    shopA.controller("IndexCtrl", function ($scope, ShopApi) {

        $scope.message = "Welcome to the Main Controller!";

        getCart();

        function getCart() {
            ShopApi.getCart().success(function (movies) {
                $scope.movies = movies;
            }).
                error(function () {
                    $scope.status = "Unable to load movies data!";
                });
        }
    });
    //shopA.controller("AddCtrl", function ($scope, ShopApi) {

    //    $scope.message = "Welcome from Add Controller!";

    //    $scope.addToCart = function () {
    //        var addToMovie = {
    //            //"Name": $scope.name,
    //            //"Age": $scope.age,
    //            //"Salary": $scope.sal
    //        };

    //        ShopApi.addToCart(addToMovie).
    //            success(function (response) {
    //                alert("Movie added.");
    //                //$scope.name = undefined;
    //                //$scope.age = undefined;
    //                //$scope.sal = undefined;
    //            }).
    //            error(function (response) {
    //                alert("Error in adding movie!");
    //            });
    //    };

    //});

})();