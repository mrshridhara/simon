/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.service("SettingsServices", ["$http", "$location",
    function ($http, $location) {
        return new SettingsServices($http, $location);
    }]);

var SettingsServices = function ($http, $location, undefined) {
    var self = this;

    this.Settings = [];
    this.Error = undefined;

    this.GetSettings = function () {
        return $http
            .get('/api/settings')
            .success(function (result) {
                self.Settings = angular.fromJson(result);
            })
            .error(function (result) {
                self.Error = result;
            });
    };

    this.UpdateSettings = function () {
        return $http
            .put('/api/settings', this.Settings)
            .success(function () {
                $location.path("/");
            })
            .error(function (result) {
                self.Error = result;
            });
    };

    this.DeleteSettings = function (eachSetting) {
        var i = this.Settings.indexOf(eachSetting);
        if (i != -1) {
            this.Settings.splice(i, 1);
        }
    };
};