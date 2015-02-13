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
        self.DeleteSettings = deleteSettings;

        function getPlugins() {
            return $http.get('/api/Plugins').success(function (result) {
                self.Plugins = angular.fromJson(result);
            });
        }

        function deleteSettings(setting) {
            angular.forEach(self.Plugins, function (eachPlugin) {
                if (eachPlugin.Settings) {
                    var i = eachPlugin.Settings.indexOf(setting);
                    if (i != -1) {
                        eachPlugin.Settings.splice(i, 1);
                    }
                }
            });
        }
    }
}(angular));