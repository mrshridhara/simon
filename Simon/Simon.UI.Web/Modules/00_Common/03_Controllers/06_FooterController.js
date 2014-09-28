/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller('FooterController', [
    '$scope',
    'FooterServices',
    function ($scope, footerServices) {
        footerServices.GetVersion();
        $scope.FooterServices = footerServices;
    }
]);