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

        vm.DeleteSettings = deleteSettings;

        activate();

        function activate() {
            try {
                pageHeadService.Title = "Global settings";
                breadcrumbService.IsVisible = false;
                navbarService.DeactivateAll();
                navbarService.SettingsMenu.SetAsActive();
                settingsService.GetSettings()
                    .success(function () {
                        updatePlugins();
                    })
                    .error(function (result) {
                        vm.Error = result;
                    });
            }
            catch (error) {
                console.log(error);
            }
        }

        function deleteSettings(setting) {
            settingsService.DeleteSettings(setting);
            pluginsService.DeleteSettings(setting);
        }

        function updatePlugins() {
            pluginsService.GetPlugins()
                .error(function (result) {
                    vm.Error = result;
                })
                .success(function (result) {
                    angular.forEach(pluginsService.Plugins, function (onePlugin) {
                        angular.forEach(settingsService.Settings, function (oneSetting) {
                            if (onePlugin.Name === oneSetting.Value.PluginName) {
                                if (!onePlugin.Settings) {
                                    onePlugin.Settings = [];
                                }
                                onePlugin.Settings.push(oneSetting);
                            }
                        });
                    });
                });
        }
    }
}(angular));