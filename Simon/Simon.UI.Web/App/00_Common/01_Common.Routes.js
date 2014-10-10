(function (angular) {
    'use strict';

    angular
        .module('Common')
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider.when('/About', {
            templateUrl: 'App/00_Common/03_Templates/About.html',
            controller: 'About',
            controllerAs: 'vm'
        }).when('/Settings', {
            templateUrl: 'App/00_Common/03_Templates/Settings.html',
            controller: 'Settings',
            controllerAs: 'vm'
        });
    }
}(angular));