/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../../SimonAppControllers.js" />

simonAppControllers.controller("AboutController", ["$scope", "$location", "NavbarServices", "BreadcrumbServices",
    function ($scope, $location, navbarServices, breadcrumbServices) {
        navbarServices.DeactivateAll();
        navbarServices.AboutMenu.SetAsActive();

        breadcrumbServices.Reset();
        breadcrumbServices.AddNew($location, "About");
        $scope.BreadcrumbServices = breadcrumbServices;
    }]);