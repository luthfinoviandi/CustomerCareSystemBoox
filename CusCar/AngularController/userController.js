/// <reference path="angular.js" />
angular.module('myApp', []);
angular.module('myApp').controller('userController', userController);

function userController($scope, $http, $q) {
    $scope.users = [];
    $scope.user = {};

    init();

    function init() {
        getUsers();
    }
    function getUsers() {
        var deffered = $q.defer();
        $http.get('/api/User').success(function (results) {
            $scope.users = results;
            deffered.resolve(results);
        }).error(function (data, status, headers, config) {
            deffered.reject('Failed getting users');
        });

        return deffered.promise;
    };

    function processError(error) {
        toastr.error(error);
    }
}