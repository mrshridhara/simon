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
        pageHeadServices.Title = 'Projects';
        breadcrumbServices.Reset();
        breadcrumbServices.AddNew($location, 'Projects');
        projectsServices.GetProjects().success(function () {
        });
        $scope.ProjectsServices = projectsServices;
    }
]);