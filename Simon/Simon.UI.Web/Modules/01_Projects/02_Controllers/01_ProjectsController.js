/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../ProjectsModule.js" />

projectsModule.controller("ProjectsController", ["$scope", "$location", "PageHeadServices", "NavbarServices", "BreadcrumbServices", "ProjectsServices",
    function ($scope, $location, pageHeadServices, navbarServices, breadcrumbServices, projectsServices) {
        navbarServices.DeactivateAll();

        pageHeadServices.Title = "Projects";

        breadcrumbServices.Reset();

        projectsServices.GetProjects()
            .success(function () {
                breadcrumbServices.AddNew($location, "Projects");
                $scope.BreadcrumbServices = breadcrumbServices;
            });
        $scope.ProjectsServices = projectsServices;
    }]);