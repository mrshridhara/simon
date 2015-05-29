(function (angular) {
    'use strict';

    angular
        .module('Applications')
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider.when('/:ProjectId/new-application', {
            templateUrl: 'App/02_Applications/03_Templates/NewApplication.html',
            controller: 'NewApplication',
            controllerAs: 'vm'
        }).when('/:ProjectId/:ApplicationId', {
            templateUrl: 'App/02_Applications/03_Templates/ApplicationDetails.html',
            controller: 'ApplicationDetails',
            controllerAs: 'vm'
        }).when('/:ProjectId/:ApplicationId/edit', {
            templateUrl: 'App/02_Applications/03_Templates/EditApplication.html',
            controller: 'EditApplication',
            controllerAs: 'vm'
        });
    }
}(angular));