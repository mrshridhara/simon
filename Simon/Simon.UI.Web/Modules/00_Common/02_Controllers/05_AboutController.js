/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller('AboutController', [
    '$scope',
    '$location',
    'NavbarServices',
    'BreadcrumbServices',
    'PageHeadServices',
    function ($scope, $location, navbarServices, breadcrumbServices, pageHeadServices) {
        navbarServices.DeactivateAll();
        navbarServices.AboutMenu.SetAsActive();
        breadcrumbServices.IsVisible = false;
        pageHeadServices.Title = "About";
    }
]);