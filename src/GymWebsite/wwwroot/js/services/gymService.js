(function () {
    'use strict';

    var gym = function ($http) {

        var getGyms = function () {
            return $http.get('/api/gym')
        };

        return {
            getGyms: getGyms
        };
    };

    var module = angular.module('app');

    module.factory('gym', gym);

})();