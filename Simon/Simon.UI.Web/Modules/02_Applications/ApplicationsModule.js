/// <reference path="../../Scripts/_references.js" />

var applicationsModule = angular.module('ApplicationsModule', [
    'ngRoute',
    'CommonModule',
    'ProjectsModule'
]);

applicationsModule.config(['$routeProvider',
    function ($routeProvider) {
        //$routeProvider
        //    .when("/:ProjectId", {
        //        templateUrl: "Modules/01_Projects/03_Templates/ProjectDetails.html",
        //        controller: "ProjectDetailsController"
        //    });
    }
]);