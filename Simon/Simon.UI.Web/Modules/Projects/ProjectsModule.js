/// <reference path="../../Scripts/_references.js" />

var projectsModule = angular.module("ProjectsModule", ["ngRoute", "CommonModule"]);

projectsModule.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/Projects", {
            templateUrl: "Modules/Projects/Templates/Projects.html",
            controller: "ProjectsController"
        })
        .when("/Projects/:ProjectId", {
            templateUrl: "Modules/Projects/Templates/ProjectDetails.html",
            controller: "ProjectDetailsController"
        });
}]);