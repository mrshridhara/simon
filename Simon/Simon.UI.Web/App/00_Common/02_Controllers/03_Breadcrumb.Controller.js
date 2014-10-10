(function (angular) {
    'use strict';

    angular
        .module('Common')
        .controller('Breadcrumb', breadcrumb);

    breadcrumb.$inject = ['BreadcrumbService'];

    function breadcrumb(breadcrumbService) {
        /* jshint validthis: true */
        var vm = this;
        vm.BreadcrumbService = breadcrumbService;
    }
}(angular));