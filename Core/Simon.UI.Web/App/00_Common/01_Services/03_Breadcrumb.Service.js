(function (angular) {
    'use strict';

    angular
        .module('Common')
        .value('BreadcrumbService', new BreadcrumbService());

    function BreadcrumbService() {
        /* jshint validthis: true */
        var self = this;

        self.RootItem = undefined;
        self.IsVisible = false;

        self.Reset = reset;
        self.GetItems = getItems;
        self.AddNew = addNew;
        self.RemoveLast = removeLast;
        self.LastContains = lastContains;

        function reset() {
            self.RootItem = undefined;
            self.IsVisible = false;
        }

        function getItems() {
            var items = [];
            if (self.RootItem) {
                self.RootItem.AddTo(items);
            }
            return items;
        }

        function addNew($location, text) {
            self.IsVisible = true;
            if (self.RootItem) {
                self.RootItem.Class = '';
                self.RootItem.SetNextWith($location, text);
            }
            else {
                self.RootItem = new BreadcrumbItem($location, text);
                self.RootItem.Class = 'active';
            }
        }

        function removeLast() {
            if (self.RootItem) {
                if (self.RootItem.IsLast()) {
                    self.Reset();
                }
                else {
                    self.RootItem.RemoveLast();
                }
            }
        }

        function lastContains(containsText) {
            if (self.RootItem) {
                return self.RootItem.LastContains(containsText);
            }
        }
    }

    function BreadcrumbItem($location, text) {
        /* jshint validthis: true */
        var self = this;

        self.Location = $location.path();
        self.Text = text;
        self.Next = undefined;
        self.Class = '';

        self.SetNextWith = setNextWith;
        self.AddTo = addTo;
        self.IsLast = isLast;
        self.RemoveLast = removeLast;
        self.LastContains = lastContains;

        function setNextWith($location, text) {
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
        }

        function addTo(items) {
            items.push(self);
            if (self.Next) {
                self.Next.AddTo(items);
            }
        }

        function isLast() {
            return !(self.Next);
        }

        function removeLast() {
            if (self.Next) {
                if (self.Next.IsLast()) {
                    self.Class = 'active';
                    self.Next = undefined;
                }
                else {
                    self.Next.RemoveLast();
                }
            }
        }

        function lastContains(containsText) {
            if (self.IsLast()) {
                return self.Text.indexOf(containsText) > -1;
            }
            else {
                return self.Next.LastContains(containsText);
            }
        }
    }
}(angular));