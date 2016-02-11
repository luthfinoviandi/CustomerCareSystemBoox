

angular
    .module('CusCar', [
    'ngRoute',
    'CusCar.ctrl.complain', 'datatables'
    ])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider.when('/', {
            templateUrl: '/View/Complain/Index.cshtml',
            controller: 'complainController'
        }).when('/View/Complain/Detail.cshtml', {
            templateUrl: '/Complain/Detail',
            controller: 'complainController'
        });


        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

    }]);