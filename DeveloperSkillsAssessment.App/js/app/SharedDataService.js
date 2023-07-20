angular.module('app', [])
    .service('SharedDataService', function () {
        var service = this;
        service.APIEndpoint = 'https://localhost:44343';
    });
