/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller('AboutController', [
    '$scope',
    '$location',
    'NavbarServices',
    'BreadcrumbServices',
    function ($scope, $location, navbarServices, breadcrumbServices) {
        navbarServices.DeactivateAll();
        navbarServices.AboutMenu.SetAsActive();
        breadcrumbServices.IsVisible = false;
    }
]);