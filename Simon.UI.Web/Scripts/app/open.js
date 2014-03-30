/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};

window.simonApi.onOpenSuccess = function (result) {
	'use strict';

	$('#item-list').hide();

	$(result).each(function (index) {
		// open the page from here.
	});
};

window.simonApi.onOpenFailed = function () { };

window.simonApi.open = function (data) {
	'use strict';

	var dataArray, domain, id, url;

	dataArray = data.split(':');

	domain = dataArray[0];
	id = dataArray[1];

	url = '/api/' + domain;

	$.get(url, { id: id })
        .success(window.simonApi.onOpenSuccess)
        .fail(window.simonApi.onOpenFailed);
};