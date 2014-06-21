/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

commonModule.service("BreadcrumbServices",
    function () {
        return new BreadcrumbServices();
    });

var BreadcrumbServices = function () {
    var self = this;

    this.Items = [];

    this.Reset = function () {
        self.Items = [];
    };

    this.AddNew = function ($location, text) {
        //self.Items.push({
        //    Href: $location.path(),
        //    Text: text
        //});
    };
};