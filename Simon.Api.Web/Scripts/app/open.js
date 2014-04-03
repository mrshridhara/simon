/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};

simonApi.onOpenSuccess = function (result) {
    'use strict';

    $(result).each(function (index) {
        simonApi.ui.breadcrumb.add(this.Name, this.Name);

        $('.details-section .content').text(index);

        simonApi.ui.hideLoading();
        $('.main-nav-section').show();
        $('.details-section').show();
    });
};

simonApi.onOpenFailed = function () {
    'use strict';

    simonApi.ui.hideLoading();
    $('.error-section').show();
};

simonApi.open = function (domain) {
    'use strict';

    var url = '/api/' + domain;

    $('.section').hide();
    simonApi.ui.showLoading();

    $.get(url)
        .success(simonApi.onOpenSuccess)
        .fail(simonApi.onOpenFailed);
};