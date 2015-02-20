(function (angular) {
    'use strict';

    angular
        .module('Projects')
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'App/01_Projects/03_Templates/Projects.html',
            controller: 'Projects',
            controllerAs: 'vm'
        }).when('/new-project', {
            templateUrl: 'App/01_Projects/03_Templates/NewProject.html',
            controller: 'NewProject',
            controllerAs: 'vm'
        }).when('/:ProjectId', {
            templateUrl: 'App/01_Projects/03_Templates/ProjectDetails.html',
            controller: 'ProjectDetails',
            controllerAs: 'vm'
        }).when('/:ProjectId/edit', {
            templateUrl: 'App/01_Projects/03_Templates/EditProject.html',
            controller: 'EditProject',
            controllerAs: 'vm'
        });
    }
}(angular));