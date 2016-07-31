(function () {
    'use strict';

    angular
        .module('app')
        .controller('gymController', gymController);

    gymController.$inject = ['gym'];

    function gymController(gym) {
        var vm = this;

        var onGymComplete = function (response) {
            vm.gymList = response.data;
        };
        var onError = function (error) {
            vm.Error = error;
        };

        gym.getGyms().then(onGymComplete, onError);
    }
})();
