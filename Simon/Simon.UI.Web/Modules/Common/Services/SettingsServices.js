/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../../SimonAppServices.js" />

simonAppServices.service("SettingsServices", ["$http",
    function ($http) {
        return new SettingsServices($http);
    }]);

var SettingsServices = function ($http, undefined) {
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
                // Show updated toastr.
            })
            .error(function (result) {
                self.Error = result;
            });
    };
};