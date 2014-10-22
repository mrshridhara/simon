(function (angular) {
    'use strict';

    angular
        .module('Common')
        .controller('Navbar', navbar);

    navbar.$inject = [
        '$http',
        'NavbarService'
    ];

    function navbar($http, navbarService) {
        /* jshint validthis: true */
        var vm = this;
        vm.NavbarService = navbarService;

        activate();

        function activate() {
            navbarService.LoadTools($http);
            navbarService.LoadUser($http);
        }
    }
}(angular));