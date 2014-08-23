/// <reference path="../../../Scripts/_references.js" />
/// <reference path="../CommonModule.js" />

var FooterServices = function ($http) {
    var self = this;
    this.Version = '';
    this.GetVersion = function () {
        $http.get('/api/SimonVersion/').success(function (result) {
            self.Version = result.DisplayText;
        });
    };
};

commonModule.service('FooterServices', [
    '$http',
    function ($http) {
        return new FooterServices($http);
    }
]);