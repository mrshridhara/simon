/// <reference path="../_references.js" />
/// <reference path="eventAttachments.js" />

window.simonApi = window.simonApi || {};

$(document).ready(function () {
	'use strict';

	var firstListAllElement;

	window.simonApi.attachListAllEvents();
	firstListAllElement = $('.nav-list-all')[0];

	$(firstListAllElement).click();
});