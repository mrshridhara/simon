/// <reference path="../../Scripts/_references.js" />

(function () {
    angular
        .module('CommonModule', [
            'ngRoute'
        ])
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider.when('/About', {
            templateUrl: 'Modules/00_Common/03_Templates/About.html',
            controller: 'AboutController',
            controllerAs: 'vm'
        }).when('/Settings', {
            templateUrl: 'Modules/00_Common/03_Templates/Settings.html',
            controller: 'SettingsController',
            controllerAs: 'vm'
        });
    }
})();