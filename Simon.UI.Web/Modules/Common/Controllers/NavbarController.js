/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../../SimonAppControllers.js" />

simonAppControllers.controller("NavbarController", ["$scope", "NavbarServices",
    function ($scope, navbarServices) {
        $scope.NavbarServices = navbarServices;
    }]);