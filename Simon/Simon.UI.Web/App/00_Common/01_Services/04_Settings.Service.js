(function (angular) {
    'use strict';

    angular
        .module('Common')
        .service('SettingsService', settingsService);

    settingsService.$inject = [
        '$http',
        '$location',
        'NavbarService'
    ];

    function settingsService($http, $location, navbarService) {
        /* jshint validthis: true */
        var self = this;

        self.Settings = [];

        self.GetSettings = getSettings;
        self.UpdateSettings = updateSettings;
        self.DeleteSettings = deleteSettings;

        function getSettings() {
            return $http.get('/api/Settings').success(function (result) {
                self.Settings = angular.fromJson(result);
                angular.forEach(self.Settings, function (eachSetting) {
                    if (!eachSetting.Value.PluginName || eachSetting.Value.PluginName === null) {
                        if (!self.NonPluginSettings) {
                            onePlugin.Settings = [];
                        }
                        self.NonPluginSettings.push(eachSetting);
                    }
                });
            }).error(function (result) {
                self.Error = result;
            });
        }

        function updateSettings() {
            return $http.post('/api/Settings', self.Settings).success(function () {
                navbarService.UpdateTools($http);
                $location.path('/');
            }).error(function (result) {
                self.Error = result;
            });
        }

        function deleteSettings(setting) {
            var i = self.Settings.indexOf(setting);
            if (i != -1) {
                self.Settings.splice(i, 1);
            }
        }
    }
}(angular));