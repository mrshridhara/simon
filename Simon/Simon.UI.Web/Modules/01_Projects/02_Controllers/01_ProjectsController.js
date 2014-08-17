/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../ProjectsModule.js" />

projectsModule.controller('ProjectsController', [
    '$scope',
    '$location',
    'PageHeadServices',
    'NavbarServices',
    'BreadcrumbServices',
    'ProjectsServices',
    function ($scope, $location, pageHeadServices, navbarServices, breadcrumbServices, projectsServices) {
        navbarServices.DeactivateAll();
        pageHeadServices.Title = 'Home';
        projectsServices.GetProjects().success(function () {
            breadcrumbServices.Reset();
            breadcrumbServices.AddNew($location, pageHeadServices.Title);
        });
        $scope.ProjectsServices = projectsServices;
    }
]);