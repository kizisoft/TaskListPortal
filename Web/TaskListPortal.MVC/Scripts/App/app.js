'use strict';

var app = angular.module('app', ['ngRoute', 'ngResource']),
    baseUrl = 'http://localhost:7891/',
    constants = {
        baseApiUrl: baseUrl + 'api/',
        baseUrl: baseUrl
    };

app.constant('constants', constants);

app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $locationProvider.hashPrefix();
    $routeProvider
        .when('/', {
            templateUrl: 'Scripts/App/templates/home.html',
            controller: 'HomeCtrl'
        })
        .otherwise({
            redirectTo: '/'
        });
}]);