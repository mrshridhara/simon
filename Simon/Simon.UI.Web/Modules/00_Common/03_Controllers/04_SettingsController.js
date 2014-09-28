/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller('SettingsController', [
    '$scope',
    '$location',
    'NavbarServices',
    'BreadcrumbServices',
    'PageHeadServices',
    'SettingsServices',
    function ($scope, $location, navbarServices, breadcrumbServices, pageHeadServices, settingsServices) {
        navbarServices.DeactivateAll();
        navbarServices.SettingsMenu.SetAsActive();
        pageHeadServices.Title = "Global settings";
        breadcrumbServices.IsVisible = false;
        settingsServices.GetSettings();
        $scope.SettingsServices = settingsServices;
    }
]);