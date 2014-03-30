/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};
simonApi.ui = simonApi.ui || {};
simonApi.ui.breadcrumb = simonApi.ui.breadcrumb || {};

simonApi.ui.breadcrumb.add = function (text, href) {
    'use strict';

    var itemContainer, item;

    item = document.createElement('a');
    $(item).attr('href', '#' + href);
    $(item).text(text);

    itemContainer = document.createElement('li');
    $(itemContainer).append(item);

    $('.breadcrumb').append(itemContainer);
};

simonApi.ui.breadcrumb.removeLast = function () {
    'use strict';

    var children, breadcrumbArray;

    children = $('.breadcrumb').children();
    breadcrumbArray = new Array(children.length - 1);

    children.each(function (index) {
        if (index < children.length - 1) {
            breadcrumbArray[index] = children[index];
        }
    });

    simonApi.removeListAllEvents();
    $('.breadcrumb').empty();
    $(breadcrumbArray).each(function () {
        $('.breadcrumb').append(this);
    });

    simonApi.attachListAllEvents();
};

simonApi.ui.breadcrumb.keepOnlyFirst = function () {
    'use strict';

    var firstItem;

    firstItem = $('.breadcrumb').children().first();

    simonApi.removeListAllEvents();
    $('.breadcrumb').empty();
    $('.breadcrumb').append(firstItem);

    simonApi.attachListAllEvents();
};

simonApi.ui.showLoading = function () {
    $('#loading').show();
};

simonApi.ui.hideLoading = function () {
    $('#loading').hide();
};