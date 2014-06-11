/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../../SimonAppControllers.js" />

simonAppControllers.controller("SettingsController", ["$scope", "$location", "NavbarServices", "BreadcrumbServices", "SettingsServices",
    function ($scope, $location, navbarServices, breadcrumbServices, settingsServices) {
        navbarServices.DeactivateAll();
        navbarServices.SettingsMenu.SetAsActive();

        breadcrumbServices.Reset();

        settingsServices.GetSettings()
            .success(function () {
                breadcrumbServices.AddNew($location, "Settings");
                $scope.BreadcrumbServices = breadcrumbServices;
            });
        $scope.SettingsServices = settingsServices;
    }]);