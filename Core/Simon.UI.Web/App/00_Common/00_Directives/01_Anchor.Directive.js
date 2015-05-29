(function (angular) {
    'use strict';

    angular
        .module('Common')
        .directive('a', anchor);

    function anchor() {
        return {
            restrict: 'E',
            link: link
        };

        function link(scope, elem, attrs) {
            if (attrs.ngClick || attrs.href === '' || attrs.href === '#') {
                elem.on('click', function (e) {
                    e.preventDefault();
                });
            }
        }
    }
}(angular));