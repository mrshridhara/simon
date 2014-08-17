﻿/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../ProjectsModule.js" />

projectsModule.controller('NewProjectController', [
    '$scope',
    '$location',
    '$routeParams',
    'PageHeadServices',
    'NavbarServices',
    'BreadcrumbServices',
    'ProjectsServices',
    function ($scope, $location, $routeParams, pageHeadServices, navbarServices, breadcrumbServices, projectsServices) {
        navbarServices.DeactivateAll();
        pageHeadServices.Title = 'Add New Project';
        breadcrumbServices.AddNew($location, 'New Project');
        $scope.ProjectsServices = projectsServices;
        $scope.NewProjectDetails = {
            Name: '',
            Description: ''
        };
    }
]);