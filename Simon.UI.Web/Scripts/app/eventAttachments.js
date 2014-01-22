/// <reference path="../_references.js" />
/// <reference path="listAll.js" />

window.simonApi = window.simonApi || {};

window.simonApi.attachListAllEvents = function () {
	'use strict';

	$('.nav-list-all').on('click', function () {
		var href, domain;

		href = $(this).attr('href');
		domain = href.replace('#', '');

		window.simonApi.listAll(domain);
	});
};

window.simonApi.removeListAllEvents = function () {
	'use strict';

	$('.nav-list-all').off('click');
};