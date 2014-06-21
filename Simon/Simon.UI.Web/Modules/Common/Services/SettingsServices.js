/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../../SimonAppServices.js" />

<<<<<<< HEAD
simonAppServices.service("SettingsServices", ["$http",
    function ($http) {
        return new SettingsServices($http);
    }]);

var SettingsServices = function ($http, undefined) {
=======
simonAppServices.service("SettingsServices", ["$http","$location",
    function ($http, $location) {
        return new SettingsServices($http, $location);
    }]);

var SettingsServices = function ($http, $location, undefined) {
>>>>>>> Readme updates and minimal file changes.
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
<<<<<<< HEAD
                // Show updated toastr.
=======
                $location.path("/");
>>>>>>> Readme updates and minimal file changes.
            })
            .error(function (result) {
                self.Error = result;
            });
    };
};