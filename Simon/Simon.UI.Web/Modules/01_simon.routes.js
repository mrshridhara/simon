(function () {
    'use strict';

    angular
        .module('simon')
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider.otherwise({
            redirectTo: '/'
        });
    }
})();