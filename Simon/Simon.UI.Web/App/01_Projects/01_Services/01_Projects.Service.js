(function (angular) {
    'use strict';

    angular
        .module('Projects')
        .service('ProjectsService', projectsService);

    projectsService.$inject = [
        '$http',
        '$location',
        'BreadcrumbService'
    ];

    function projectsService($http, $location, breadcrumbService) {
        /* jshint validthis: true */
        var self = this;

        self.Projects = [];
        self.Error = undefined;
        self.SelectedProject = undefined;

        self.GetProjects = getProjects;
        self.GetProjectDetails = getProjectDetails;
        self.AddProject = addProject;
        self.UpdateProject = updateProject;

        function getProjects() {
            return $http.get('/api/projects').success(function (result) {
                self.Projects = angular.fromJson(result);
            }).error(function (result) {
                self.Error = result;
            });
        }

        function getProjectDetails(projectId) {
            return $http.get('/api/projects/' + projectId).success(function (result) {
                self.SelectedProject = angular.fromJson(result);
            }).error(function (result) {
                self.Error = result;
            });
        }

        function addProject(newProjectDetails) {
            return $http.post('/api/projects/', newProjectDetails).success(function (result) {
                breadcrumbService.RemoveLast();
                $location.path('/' + result.Id);
            }).error(function (result) {
                self.Error = result;
            });
        }

        function updateProject() {
            return $http.post('/api/projects/', self.SelectedProject).success(function () {
                breadcrumbService.RemoveLast();
                $location.path('/' + self.SelectedProject.Id);
            }).error(function (result) {
                self.Error = result;
            });
        }
    }
}(angular));