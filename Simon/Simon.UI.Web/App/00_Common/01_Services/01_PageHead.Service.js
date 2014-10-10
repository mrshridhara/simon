(function (angular) {
    'use strict';

    angular
        .module('Common')
        .value('PageHeadService', new PageHeadService());

    function PageHeadService() {
        /* jshint validthis: true */
        var self = this;

        self.Title = '';
    }
}(angular));