(function (angular) {
    'use strict';

    angular
        .module('Common')
        .service('PluginsService', pluginsService);

    pluginsService.$inject = ['$http'];

    function pluginsService($http) {
        /* jshint validthis: true */
        var self = this;

        self.Plugins = undefined;

        self.GetPlugins = getPlugins;

        function getPlugins() {
            return $http.get('/api/Plugins').success(function (result) {
                self.Plugins = angular.fromJson(result);
            });
        }
    }
}(angular));