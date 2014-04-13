/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};

simonApi.onListAllFailed = function () {
    'use strict';

    $('#item-list').empty
    simonApi.ui.hideLoading();
    $('.error-section').show();
};

simonApi.listAll = function (domain, listAllSuccessCallBack) {
    'use strict';

    var url = 'http://localhost/Simon.Api.Web/' + domain;

    $('.section').hide();
    simonApi.ui.showLoading();

    $.get(url)
        .success(listAllSuccessCallBack)
        .fail(simonApi.onListAllFailed);
};