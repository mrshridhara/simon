/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../ProjectsModule.js" />

projectsModule.service("ProjectsServices", ["$http",
    function ($http) {
        return new ProjectsServices($http);
    }]);

var ProjectsServices = function ($http, undefined) {
    var self = this;

    this.Projects = [];
    this.Error = undefined;
    this.SelectedProject = undefined;

    this.GetProjects = function () {
        return $http
            .get('/api/projects')
            .success(function (result) {
                self.Projects = angular.fromJson(result);
            })
            .error(function (result) {
                self.Error = result;
            });
    };

    this.GetProjectDetails = function (projectId) {
        return $http
            .get('/api/projects/' + projectId)
            .success(function (result) {
                self.SelectedProject = angular.fromJson(result);
            })
            .error(function (result) {
                self.Error = result;
            });
    };
};