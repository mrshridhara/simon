(function (angular) {
    'use strict';

    angular
        .module('Common')
        .value('NavbarService', new NavbarService());

    function NavbarService() {
        /* jshint validthis: true */
        var self = this;

        self.AboutMenu = new NavbarMenu('/About', 'About');
        self.SettingsMenu = new NavbarMenu('/Settings', 'Settings');
        self.Tools = undefined;
        self.User = undefined;

        self.DeactivateAll = deactivateAll;
        self.LoadTools = loadTools;
        self.LoadUser = loadUser;

        function deactivateAll() {
            self.AboutMenu.Class = '';
            self.SettingsMenu.Class = '';
        }

        function loadTools($http) {
            $http.get('/api/PluginPaths').success(function (result) {
                self.Tools = angular.fromJson(result);
            });
        }

        function loadUser($http) {
            $http.get('/api/User').success(function (result) {
                self.User = angular.fromJson(result);
            });
        }
    }

    function NavbarMenu(path, text) {
        /* jshint validthis: true */
        var self = this;

        self.IsActive = false;
        self.Class = '';
        self.Path = path;
        self.Text = text;

        self.SetAsActive = setAsActive;

        function setAsActive() {
            self.IsActive = true;
            self.Class = 'active';
        }
    }
}(angular));