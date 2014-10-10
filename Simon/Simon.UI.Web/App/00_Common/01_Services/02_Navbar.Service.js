(function (angular) {
    'use strict';

    angular
        .module('Common')
        .value('NavbarService', new NavbarService());

    function NavbarService() {
        /* jshint validthis: true */
        var self = this;

        self.AboutMenu = new NavbarMenu('/About');
        self.SettingsMenu = new NavbarMenu('/Settings');
        self.Tools = undefined;

        self.DeactivateAll = deactivateAll;
        self.UpdateTools = updateTools;

        function deactivateAll() {
            self.AboutMenu.Class = '';
            self.SettingsMenu.Class = '';
        }

        function updateTools($http) {
            $http.get('/api/PluginPaths').success(function (result) {
                self.Tools = angular.fromJson(result);
            });
        }
    }

    function NavbarMenu(path) {
        /* jshint validthis: true */
        var self = this;

        self.IsActive = false;
        self.Class = '';
        self.Path = path;

        self.SetAsActive = setAsActive;

        function setAsActive() {
            self.IsActive = true;
            self.Class = 'active';
        }
    }
}(angular));