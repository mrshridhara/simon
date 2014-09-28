/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller('NavbarController', [
    '$scope',
    '$http',
    'NavbarServices',
    function ($scope, $http, navbarServices) {
        navbarServices.UpdateTools($http);
        $scope.NavbarServices = navbarServices;
    }
]);