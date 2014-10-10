(function (angular) {
    'use strict';

    angular
        .module('Common')
        .controller('Footer', footer);

    footer.$inject = ['FooterService'];

    function footer(footerService) {
        /* jshint validthis: true */
        var vm = this;
        vm.FooterService = footerService;

        activate();

        function activate() {
            footerService.GetVersion();
        }
    }
}(angular));