(function (angular) {
    'use strict';

    angular
        .module('Common')
        .controller('Settings', settings);

    settings.$inject = [
        '$location',
        'PageHeadService',
        'BreadcrumbService',
        'NavbarService',
        'SettingsService'
    ];

    function settings($location, pageHeadService, breadcrumbService, navbarService, settingsService) {
        /* jshint validthis: true */
        var vm = this;
        vm.PageHeadService = pageHeadService;
        vm.BreadcrumbService = breadcrumbService;
        vm.NavbarService = navbarService;
        vm.SettingsService = settingsService;

        activate();

        function activate() {
            try {
                pageHeadService.Title = "Global settings";
                breadcrumbService.IsVisible = false;
                navbarService.DeactivateAll();
                navbarService.SettingsMenu.SetAsActive();
                settingsService.GetSettings();
            }
            catch (error) {
                console.log(error);
            }
        }
    }
}(angular));