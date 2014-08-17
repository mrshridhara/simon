/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../ProjectsModule.js" />

projectsModule.controller('EditProjectController', [
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
            pageHeadServices.Title = 'Edit ' + projectsServices.SelectedProject.Name;
            breadcrumbServices.RemoveLast();
            breadcrumbServices.AddNew($location, pageHeadServices.Title);
        });
        $scope.ProjectsServices = projectsServices;
    }
]);