/// <reference path="../../Scripts/_references.js" />

var commonModule = angular.module("CommonModule", ["ngRoute"]);

commonModule.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/About", {
            templateUrl: "Modules/Common/Templates/About.html",
            controller: "AboutController"
        })
        .when("/Settings", {
            templateUrl: "Modules/Common/Templates/Settings.html",
            controller: "SettingsController"
        });
}]);