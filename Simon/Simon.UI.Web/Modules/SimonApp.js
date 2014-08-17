/// <reference path="../Scripts/_references.js" />

var simonApp = angular.module('SimonApp', [
    'ngRoute',
    'CommonModule',
    'ProjectsModule',
    'ApplicationsModule'
]);

simonApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.otherwise({
            redirectTo: '/'
        });
    }
]);