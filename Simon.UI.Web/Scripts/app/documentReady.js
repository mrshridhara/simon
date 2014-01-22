/// <reference path="../_references.js" />
/// <reference path="eventAttachments.js" />

window.simonApi = window.simonApi || {};

$(document).ready(function () {
	'use strict';

	window.simonApi.attachListAllEvents();

	$($('.nav-list-all')[0]).click();
});