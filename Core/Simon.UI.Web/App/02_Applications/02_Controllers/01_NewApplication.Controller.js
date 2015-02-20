(function (angular) {
    'use strict';

    angular
        .module('Applications')
        .controller('NewApplication', newApplication);

    newApplication.$inject = [
        '$location',
        '$routeParams',
        'PageHeadService',
        'NavbarService',
        'BreadcrumbService',
        'ApplicationsService'
    ];

    function newApplication($location, $routeParams, pageHeadService, navbarService, breadcrumbService, applicationsService) {
        /* jshint validthis: true */
        var vm = this;
        vm.ApplicationsService = applicationsService;
        vm.NewApplicationDetails = {
            Name: '',
            Description: ''
        };

        activate();

        function activate() {
            pageHeadService.Title = 'Add New Application';
            navbarService.DeactivateAll();
            breadcrumbService.AddNew($location, pageHeadService.Title);
        }
    }
}(angular));