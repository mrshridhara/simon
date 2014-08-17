/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller('BreadcrumbController', [
    '$scope',
    'BreadcrumbServices',
    function ($scope, breadcrumbServices) {
        $scope.BreadcrumbServices = breadcrumbServices;
    }
]);