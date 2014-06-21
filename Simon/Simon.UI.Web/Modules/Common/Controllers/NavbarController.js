/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller("NavbarController", ["$scope", "NavbarServices",
    function ($scope, navbarServices) {
        $scope.NavbarServices = navbarServices;
    }]);