(function (angular) {
    'use strict';

    angular
        .module('Applications')
        .controller('EditApplication', editApplication);

    editApplication.$inject = [
        '$location',
        '$routeParams',
        'PageHeadService',
        'NavbarService',
        'BreadcrumbService',
        'ApplicationsService'
    ];

    function editApplication($location, $routeParams, pageHeadService, navbarService, breadcrumbService, applicationsService) {
        /* jshint validthis: true */
    }
}(angular));