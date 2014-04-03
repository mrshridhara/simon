/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};

simonApi.attachListAllEvents = function () {
    'use strict';

    $('.nav-list-all').on('click', function () {
        var href, domain;

        href = $(this).attr('href');
        domain = href.replace('#', '');

        simonApi.listAll(domain, simonApi.onListAllProjectsSuccess);
    });
};

simonApi.removeListAllEvents = function () {
    'use strict';

    $('.nav-list-all').off('click');
};

simonApi.attachOpenProjectEvent = function (openElement) {
    'use strict';

    $(openElement).on('click', function () {
        var href, data;

        href = $(this).attr('href');
        data = href.replace('#', '');

        simonApi.open(data);
    });
};

simonApi.removeOpenProjectEvent = function (openElement) {
    'use strict';

    $(openElement).off('click');
};