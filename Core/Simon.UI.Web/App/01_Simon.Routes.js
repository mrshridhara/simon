(function (angular) {
    'use strict';

    angular
        .module('Simon')
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider.otherwise({
            redirectTo: '/'
        });
    }
}(angular));