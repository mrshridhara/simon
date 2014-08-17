/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller('SettingsController', [
    '$scope',
    '$location',
    'NavbarServices',
    'BreadcrumbServices',
    'SettingsServices',
    function ($scope, $location, navbarServices, breadcrumbServices, settingsServices) {
        navbarServices.DeactivateAll();
        navbarServices.SettingsMenu.SetAsActive();
        breadcrumbServices.IsVisible = false;
        settingsServices.GetSettings().success(function () {
        });
        $scope.SettingsServices = settingsServices;
    }
]);