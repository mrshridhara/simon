/// <reference path="../_references.js" />
/// <reference path="listAll.js" />
/// <reference path="open.js" />

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

window.simonApi.attachOpenProjectEvent = function (openElement) {
	'use strict';

	$(openElement).on('click', function () {
		var href, data;

		href = $(this).attr('href');
		data = href.replace('#', '');

		window.simonApi.open(data);
	});
};