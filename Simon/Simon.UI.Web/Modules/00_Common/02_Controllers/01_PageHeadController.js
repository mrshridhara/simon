/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.controller("PageHeadController", ["$scope", "PageHeadServices",
    function ($scope, pageHeadServices) {
        $scope.PageHeadServices = pageHeadServices;
    }]);