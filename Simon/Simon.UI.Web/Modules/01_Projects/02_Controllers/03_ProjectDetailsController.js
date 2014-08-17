/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../ProjectsModule.js" />

projectsModule.controller('ProjectDetailsController', [
    '$scope',
    '$location',
    '$routeParams',
    'PageHeadServices',
    'NavbarServices',
    'BreadcrumbServices',
    'ProjectsServices',
    function ($scope, $location, $routeParams, pageHeadServices, navbarServices, breadcrumbServices, projectsServices) {
        navbarServices.DeactivateAll();
        projectsServices.GetProjectDetails($routeParams.ProjectId).success(function () {
            pageHeadServices.Title = projectsServices.SelectedProject.Name;
            breadcrumbServices.AddNew($location, projectsServices.SelectedProject.Name);
        });
        $scope.ProjectsServices = projectsServices;
    }
]);