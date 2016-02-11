
angular
    .module('CusCar.ctrl.complain', [])
    .controller('loginController', [
        '$scope', function ($scope) {
            $scope.login = function () {
                console.log($scope.user)
                $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify($scope.user),
                    url: '/LoginApi/Login',
                    success: function (result) {
                        if (result.IsLogin) {
                            window.location = "/Complain/Index";
                        }
                        else {
                            $('.alert').removeClass("hide");
                        }
                    },
                    error: function (status) { }
                });
            };

        }
    ]);