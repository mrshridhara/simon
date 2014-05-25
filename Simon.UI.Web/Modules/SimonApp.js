/// <reference path="../Scripts/_references.js" />

var simonApp = angular.module("SimonApp", ["ngRoute", "SimonAppDirectives", "SimonAppControllers", "SimonAppServices"]);

simonApp.config(function ($routeProvider) {
    $routeProvider
        .when("/About", {
            templateUrl: "Modules/Common/Templates/About.html",
            controller: "AboutController"
        });

    $routeProvider
        .when("/Projects", {
            templateUrl: "Modules/Projects/Templates/Projects.html",
            controller: "ProjectsController"
        })
        .when("/Projects/:ProjectId", {
            templateUrl: "Modules/Projects/Templates/ProjectDetails.html",
            controller: "ProjectDetailsController"
        });

    $routeProvider.otherwise({
        redirectTo: "/Projects"
    });
});