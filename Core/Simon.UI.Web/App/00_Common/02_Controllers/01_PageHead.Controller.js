(function (angular) {
    'use strict';

    angular
        .module('Common')
        .controller('PageHead', pageHead);

    pageHead.$inject = ['PageHeadService'];

    function pageHead(pageHeadService) {
        /* jshint validthis: true */
        var vm = this;
        vm.PageHeadService = pageHeadService;
    }
}(angular));