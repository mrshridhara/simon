/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../../SimonAppServices.js" />

simonAppServices.service("NavbarServices",
    function () {
        return new NavbarServices();
    });

var NavbarServices = function () {
    var self = this;

    this.ApiDocumentationMenu = new NavbarMenu();
    this.AboutMenu = new NavbarMenu();
    this.SettingsMenu = new NavbarMenu();

    this.DeactivateAll = function () {
        self.ApiDocumentationMenu.Class = "";
        self.AboutMenu.Class = "";
        self.SettingsMenu.Class = "";
    }
};

var NavbarMenu = function () {
    var self = this;

    this.IsActive = false;
    this.Class = "";

    this.SetAsActive = function () {
        self.IsActive = true;
        self.Class = "active";
    };
};