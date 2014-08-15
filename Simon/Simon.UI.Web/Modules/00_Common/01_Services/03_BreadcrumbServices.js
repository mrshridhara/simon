/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

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

(function () {
    var singletonInstance = new BreadcrumbServices();
    commonModule.value("BreadcrumbServices", singletonInstance);
})();