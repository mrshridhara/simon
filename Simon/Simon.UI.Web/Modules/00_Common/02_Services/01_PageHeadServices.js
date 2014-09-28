/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

var PageHeadServices = function (datetime) {
    var self = this;
    this.Tile = '';
    this.Date = datetime;
};

(function () {
    var currentdate = new Date();
    var datetime = currentdate.getDate() + '/'
    + (currentdate.getMonth() + 1) + '/'
    + currentdate.getFullYear() + ' @ '
    + currentdate.getHours() + ':'
    + currentdate.getMinutes() + ':'
    + currentdate.getSeconds();

    var singletonInstance = new PageHeadServices(datetime);
    commonModule.value('PageHeadServices', singletonInstance);
})();