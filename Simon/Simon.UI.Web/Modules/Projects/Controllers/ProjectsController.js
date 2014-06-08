﻿/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../../SimonAppControllers.js" />

simonAppControllers.controller("ProjectsController", ["$scope", "$location", "NavbarServices", "BreadcrumbServices", "ProjectsServices",
    function ($scope, $location, navbarServices, breadcrumbServices, projectsServices) {
        navbarServices.DeactivateAll();

        breadcrumbServices.Reset();

        projectsServices.GetProjects()
            .success(function () {
                breadcrumbServices.AddNew($location, "Projects");
                $scope.BreadcrumbServices = breadcrumbServices;
            });
        $scope.ProjectsServices = projectsServices;
    }]);