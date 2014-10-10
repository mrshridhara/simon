(function (angular) {
    'use strict';

    angular
        .module('Common')
        .service('FooterService', footerService);

    footerService.$inject = ['$http'];

    function footerService($http) {
        /* jshint validthis: true */
        var self = this;

        self.Version = '';

        self.GetVersion = getVersion;

        function getVersion() {
            $http.get('/api/SimonVersion/').success(function (result) {
                self.Version = result.DisplayText;
            });
        }
    }
}(angular));