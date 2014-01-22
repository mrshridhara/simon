/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};

window.simonApi.buildItem = function (itemData, index) {
	'use strict';

	var tableRow, slnoTableCell, nameTableCell, descriptionTableCell, actionTableCell, openAction;

	slnoTableCell = document.createElement('td');
	$(slnoTableCell).text(index + 1);

	nameTableCell = document.createElement('td');
	$(nameTableCell).text(itemData.Name);

	descriptionTableCell = document.createElement('td');
	$(descriptionTableCell).text(itemData.Description);

	openAction = document.createElement('a');
	$(openAction).attr('href', '#');
	$(openAction).text('Open');
	$(openAction).addClass('btn');
	$(openAction).addClass('btn-default');
	$(openAction).addClass('btn-sm');

	actionTableCell = document.createElement('td');
	$(actionTableCell).append(openAction);

	tableRow = document.createElement('tr');
	$(tableRow).append(slnoTableCell);
	$(tableRow).append(nameTableCell);
	$(tableRow).append(descriptionTableCell);
	$(tableRow).append(actionTableCell);

	return tableRow;
};

window.simonApi.onListAllSuccess = function (result) {
	'use strict';

	$('#item-list').empty();

	$(result).each(function (index) {
		var item = window.simonApi.buildItem(this, index);
		$('#item-list').append(item);
	});
};

window.simonApi.onListAllFailed = function () {
	'use strict';

	$('#item-list').empty();
};

window.simonApi.listAll = function (domain) {
	'use strict';

	var url = '/api/' + domain;

	$.get(url)
        .success(window.simonApi.onListAllSuccess)
        .fail(window.simonApi.onListAllFailed);
};