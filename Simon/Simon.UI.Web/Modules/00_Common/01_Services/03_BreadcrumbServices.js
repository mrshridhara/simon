/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

var BreadcrumbItem = function ($location, text, undefined) {
    var self = this;
    this.Location = $location.path();
    this.Text = text;
    this.Next = undefined;
    this.AddNew = function ($location, text) {
        if (self.Next) {
            self.Next.AddNew($location, text);
        }
        else {
            self.Next = new BreadcrumbItem($location, text);
        }
    };
};

var BreadcrumbServices = function (undefined) {
    var self = this;
    this.RootItem = undefined;
    this.IsVisible = false;
    this.Reset = function () {
        self.RootItem = undefined;
    };
    this.GetItems = function () {
    };
    this.AddNew = function ($location, text) {
        if (this.RootItem) {
            self.RootItem.AddNew($location, text);
        }
        else {
            self.RootItem = new BreadcrumbItem($location, text);
        }
    };
};

(function () {
    var singletonInstance = new BreadcrumbServices();
    commonModule.value('BreadcrumbServices', singletonInstance);
})();