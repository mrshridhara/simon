/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

var NavbarServices = function (undefined) {
    var self = this;
    this.AboutMenu = new NavbarMenu('/About');
    this.SettingsMenu = new NavbarMenu('/Settings');
    this.Tools = undefined;
    this.DeactivateAll = function () {
        self.AboutMenu.Class = '';
        self.SettingsMenu.Class = '';
    }
    this.UpdateTools = function ($http) {
        $http.get('/api/PluginPaths').success(function (result) {
            self.Tools = angular.fromJson(result);
        });
    };
};

var NavbarMenu = function (path) {
    var self = this;
    this.IsActive = false;
    this.Class = '';
    this.Path = path;
    this.SetAsActive = function () {
        self.IsActive = true;
        self.Class = 'active';
    };
};

(function () {
    var singletonInstance = new NavbarServices();
    commonModule.value('NavbarServices', singletonInstance);
})();