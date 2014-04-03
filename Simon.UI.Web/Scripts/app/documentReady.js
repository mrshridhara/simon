/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};

$(document).ready(function () {
    'use strict';

    var firstListAllElement;

    simonApi.attachListAllEvents();
    firstListAllElement = $('.nav-list-all')[0];

    $(firstListAllElement).click();
});