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
        'SettingsService',
        'PluginsService'
    ];

    function settings($location, pageHeadService, breadcrumbService, navbarService, settingsService, pluginsService) {
        /* jshint validthis: true */
        var vm = this;
        vm.Error = undefined;
        vm.PageHeadService = pageHeadService;
        vm.BreadcrumbService = breadcrumbService;
        vm.NavbarService = navbarService;
        vm.SettingsService = settingsService;
        vm.PluginsService = pluginsService;

        activate();

        function activate() {
            try {
                pageHeadService.Title = "Global settings";
                breadcrumbService.IsVisible = false;
                navbarService.DeactivateAll();
                navbarService.SettingsMenu.SetAsActive();
                settingsService.GetSettings().error(function (result) {
                    vm.Error = result;
                });
                pluginsService.GetPlugins().error(function (result) {
                    vm.Error = result;
                });
            }
            catch (error) {
                console.log(error);
            }
        }
    }
}(angular));