/// <reference path="../../Scripts/_references.js" />

var projectsModule = angular.module("ProjectsModule", ["ngRoute", "CommonModule"]);

projectsModule.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "Modules/01_Projects/03_Templates/Projects.html",
            controller: "ProjectsController"
        })
        .when("/new-project", {
            templateUrl: "Modules/01_Projects/03_Templates/NewProject.html",
            controller: "NewProjectController"
        })
        .when("/:ProjectId", {
            templateUrl: "Modules/01_Projects/03_Templates/ProjectDetails.html",
            controller: "ProjectDetailsController"
        });
}]);