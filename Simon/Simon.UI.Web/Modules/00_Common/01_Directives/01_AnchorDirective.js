/// <reference path="../../../Scripts/_references.js" />

(function () {
    angular
        .module('CommonModule')
        .directive('a', anchorDirective);

    function anchorDirective() {
        return {
            restrict: 'E',
            link: link
        };

        function link(scope, elem, attrs) {
            if (attrs.ngClick
                || attrs.href === ''
                || attrs.href === '#') {
                elem.on('click', function (e) {
                    e.preventDefault();
                });
            }
        }
    }
})();