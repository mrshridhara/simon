(function (angular) {
    'use strict';

    angular
        .module('Applications')
        .service('ApplicationsService', applicationsService);

    applicationsService.$inject = [
        '$http',
        '$location',
        'BreadcrumbService'
    ];

    function applicationsService($http, $location, breadcrumbService) {
        /* jshint validthis: true */
        var self = this;

        self.Applications = [];
        self.Error = undefined;
        self.SelectedApplication = undefined;

        self.GetApplicationDetails = getApplicationDetails;
        self.AddApplication = addApplication;
        self.UpdateApplication = updateApplication;

        function getApplicationDetails(projectId, applicationId) {
            return $http.get('/api/applications?projectId=' + projectId + '&applicationId=' + applicationId).success(function (result) {
                self.SelectedApplication = angular.fromJson(result);
            }).error(function (result) {
                self.Error = result;
            });
        }

        function addApplication(projectId, newApplicationDetails) {
            return $http.post('/api/applications?projectId=' + projectId, newApplicationDetails).success(function (result) {
                breadcrumbService.RemoveLast();
                $location.path('/' + projectId + '/' + result.Id);
            }).error(function (result) {
                self.Error = result;
            });
        }

        function updateApplication(projectId) {
            return $http.post('/api/applications?projectId=' + projectId, self.SelectedApplication).success(function () {
                breadcrumbService.RemoveLast();
                $location.path('/' + projectId + '/' + self.SelectedApplication.Id);
            }).error(function (result) {
                self.Error = result;
            });
        }
    }
}(angular));