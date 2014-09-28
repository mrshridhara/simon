/// <reference path="../../../Scripts/_references.js" />

(function () {
    angular
        .module('CommonModule')
        .controller('PageHeadController', PageHeadController);

    PageHeadController.$inject = ['PageHeadServices'];

    function PageHeadController(pageHeadServices) {
        var vm = this;
        vm.PageHeadServices = pageHeadServices;
    }
})();