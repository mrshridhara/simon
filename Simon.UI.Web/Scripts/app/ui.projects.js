/// <reference path="../_references.js" />

window.simonApi = window.simonApi || {};
simonApi.ui = simonApi.ui || {};

simonApi.ui.buildProjectItem = function (itemData, index) {
    'use strict';

    var tableRow, slnoTableCell, nameTableCell, descriptionTableCell, actionTableCell, openAction;

    slnoTableCell = document.createElement('td');
    $(slnoTableCell).text(index + 1);

    nameTableCell = document.createElement('td');
    $(nameTableCell).text(itemData.Name);

    descriptionTableCell = document.createElement('td');
    $(descriptionTableCell).text(itemData.Description);

    openAction = document.createElement('a');
    $(openAction).attr('href', '#projects/' + itemData.Id);
    $(openAction).text('Open');
    $(openAction).addClass('btn');
    $(openAction).addClass('btn-default');
    $(openAction).addClass('btn-sm');

    simonApi.attachOpenProjectEvent(openAction);

    actionTableCell = document.createElement('td');
    $(actionTableCell).append(openAction);

    tableRow = document.createElement('tr');
    $(tableRow).append(slnoTableCell);
    $(tableRow).append(nameTableCell);
    $(tableRow).append(descriptionTableCell);
    $(tableRow).append(actionTableCell);

    return tableRow;
};