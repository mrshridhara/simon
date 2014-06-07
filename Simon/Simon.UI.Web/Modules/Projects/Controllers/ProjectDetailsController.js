/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../../SimonAppControllers.js" />

simonAppControllers.controller("ProjectDetailsController", ["$scope", "$location", "$routeParams", "NavbarServices", "BreadcrumbServices", "ProjectsServices",
    function ($scope, $location, $routeParams, navbarServices, breadcrumbServices, projectsServices) {
        navbarServices.DeactivateAll();

        projectsServices.GetProjectDetails($routeParams.ProjectId)
            .success(function () {
                breadcrumbServices.AddNew($location, projectsServices.SelectedProject.Name);
                $scope.BreadcrumbServices = breadcrumbServices;
            });
        $scope.ProjectsServices = projectsServices;
    }]);