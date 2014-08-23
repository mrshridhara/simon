/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../ProjectsModule.js" />

var ProjectsServices = function ($http, $location, breadcrumbServices, undefined) {
    var self = this;
    this.Projects = [
    ];
    this.Error = undefined;
    this.SelectedProject = undefined;
    this.GetProjects = function () {
        return $http.get('/api/projects').success(function (result) {
            self.Projects = angular.fromJson(result);
        }).error(function (result) {
            self.Error = result;
        });
    };
    this.GetProjectDetails = function (projectId) {
        return $http.get('/api/projects/' + projectId).success(function (result) {
            self.SelectedProject = angular.fromJson(result);
        }).error(function (result) {
            self.Error = result;
        });
    };
    this.AddProject = function (newProjectDetails) {
        return $http.post('/api/projects/', newProjectDetails).success(function (result) {
            breadcrumbServices.RemoveLast();
            $location.path('/' + result.Id);
        }).error(function (result) {
            self.Error = result;
        });
    }
    this.UpdateProject = function () {
        return $http.post('/api/projects/', self.SelectedProject).success(function () {
            breadcrumbServices.RemoveLast();
            $location.path('/' + self.SelectedProject.Id);
        }).error(function (result) {
            self.Error = result;
        });
    }
};

projectsModule.service('ProjectsServices', [
    '$http',
    '$location',
    'BreadcrumbServices',
    function ($http, $location, breadcrumbServices) {
        return new ProjectsServices($http, $location, breadcrumbServices);
    }
]);