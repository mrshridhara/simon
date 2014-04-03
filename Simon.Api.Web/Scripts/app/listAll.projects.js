/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};

simonApi.onListAllProjectsSuccess = function (result) {
    'use strict';

    $('#item-list').each(function (index) {
        simonApi.removeOpenProjectEvent(this);
    });

    $('#item-list').empty();

    $(result).each(function (index) {
        var item = simonApi.ui.buildProjectItem(this, index);
        $('#item-list').append(item);
    });

    simonApi.ui.breadcrumb.keepOnlyFirst();

    $('.list-section .heading').text("Available projects");
    $('.list-section .add-new').text("Add New Project");
    $('.list-section .add-new').attr('href', "#add-projects");

    simonApi.ui.hideLoading();
    $('.main-nav-section').show();
    $('.list-section').show();
};