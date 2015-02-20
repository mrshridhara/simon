(function (angular) {
    'use strict';

    angular
        .module('Projects')
        .controller('ProjectDetails', projectDetails);

    projectDetails.$inject = [
        '$location',
        '$routeParams',
        'PageHeadService',
        'NavbarService',
        'BreadcrumbService',
        'ProjectsService'
    ];

    function projectDetails($location, $routeParams, pageHeadService, navbarService, breadcrumbService, projectsService) {
        /* jshint validthis: true */
        var vm = this;
        vm.ProjectsService = projectsService;

        activate();

        function activate() {
            navbarService.DeactivateAll();
            projectsService.GetProjectDetails($routeParams.ProjectId).success(function () {
                pageHeadService.Title = projectsService.SelectedProject.Name;

                if (breadcrumbService.LastContains('Edit ')) {
                    breadcrumbService.RemoveLast();
                }
                breadcrumbService.AddNew($location, pageHeadService.Title);
            });
        }
    }
}(angular));