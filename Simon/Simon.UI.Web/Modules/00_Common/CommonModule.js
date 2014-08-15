/// <reference path="../../Scripts/_references.js" />

var commonModule = angular.module("CommonModule", ["ngRoute"]);

commonModule.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/About", {
            templateUrl: "Modules/00_Common/03_Templates/About.html",
            controller: "AboutController"
        })
        .when("/Settings", {
            templateUrl: "Modules/00_Common/03_Templates/Settings.html",
            controller: "SettingsController"
        });
}]);