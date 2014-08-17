/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

var BreadcrumbItem = function ($location, text, undefined) {
    var self = this;
    this.Location = $location.path();
    this.Text = text;
    this.Next = undefined;
    this.Class = '';
    this.SetNextWith = function ($location, text) {
        if (self.Next) {
            if ($location) {
                self.Next.Class = '';
                self.Next.SetNextWith($location, text);
            }
            else if (!self.Next.Next) {
                self.Class = 'active';
                self.Next = undefined;
            }
        }
        else {
            self.Next = new BreadcrumbItem($location, text);
            self.Next.Class = 'active';
        }
    };
    this.AddTo = function (items) {
        items.push(self);
        if (self.Next) {
            self.Next.AddTo(items);
        }
    };
    this.IsLast = function () {
        return !(self.Next);
    }
    this.RemoveLast = function () {
        if (this.Next) {
            if (self.Next.IsLast()) {
                self.Class = 'active';
                self.Next = undefined;
            }
            else {
                self.Next.RemoveLast();
            }
        }
    };
};

var BreadcrumbServices = function (undefined) {
    var self = this;
    this.RootItem = undefined;
    this.IsVisible = false;
    this.Reset = function () {
        self.RootItem = undefined;
        self.IsVisible = false;
    };
    this.GetItems = function () {
        var items = new Array();
        if (self.RootItem) {
            self.RootItem.AddTo(items);
        }
        return items;
    };
    this.AddNew = function ($location, text) {
        self.IsVisible = true;
        if (this.RootItem) {
            self.RootItem.Class = '';
            self.RootItem.SetNextWith($location, text);
        }
        else {
            self.RootItem = new BreadcrumbItem($location, text);
            self.RootItem.Class = 'active';
        }
    };
    this.RemoveLast = function () {
        if (this.RootItem) {
            if (self.RootItem.IsLast()) {
                self.Reset();
            }
            else {
                self.RootItem.RemoveLast();
            }
        }
    };
};

(function () {
    var singletonInstance = new BreadcrumbServices();
    commonModule.value('BreadcrumbServices', singletonInstance);
})();