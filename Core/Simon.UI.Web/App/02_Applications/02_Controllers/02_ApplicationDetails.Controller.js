(function (angular) {
    'use strict';

    angular
        .module('Applications')
        .controller('ApplicationDetails', applicationDetails);

    applicationDetails.$inject = [
        '$location',
        '$routeParams',
        'PageHeadService',
        'NavbarService',
        'BreadcrumbService',
        'ApplicationsService'
    ];

    function applicationDetails($location, $routeParams, pageHeadService, navbarService, breadcrumbService, applicationsService) {
        /* jshint validthis: true */
    }
}(angular));