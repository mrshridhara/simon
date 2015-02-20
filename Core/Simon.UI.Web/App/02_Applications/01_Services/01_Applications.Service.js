(function (angular) {
    'use strict';

    angular
        .module('Applications')
        .service('ApplicationsService', applicationsService);

    applicationsService.$inject = [
        '$http',
        '$location',
        'BreadcrumbService'
    ];

    function applicationsService($http, $location, breadcrumbService) {
        /* jshint validthis: true */
    }
}(angular));