
angular
    .module('CusCar.ctrl.complain', ['datatables'])
    .controller('complainController', [
        '$scope', function ($scope) {

            $scope.complainList = [];
            $scope.userStatus;

            $scope.load;
            $scope.getUserStatus;
            $(".save-alert").hide();
            $(".delete-alert").hide();

            $scope.load = function () {
                $.ajax({
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    url: '/ComplainApi/Get',
                    success: function (data) {
                        $scope.complainList = data
                        $scope.$apply();
                    }
                });
            }

            $scope.getUserStatus = function () {
                
                $.ajax({
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    url: '/UserApi/GetUserStatus',
                    success: function (result) {
                        $scope.userStatus = result.userStatus;
                        $scope.$apply();
                    }
                });

            }

            $scope.load();
            $scope.getUserStatus();

            $scope.complain = {
                complainId: '',
                complainSubject: '',
                complainText: '',
                complainStatusId: '',
                complainStatusText: ''
            }

            $scope.clear = function () {
                $scope.complain.complainId = '';
                $scope.complain.complainSubject = '';
                $scope.complain.complainText = '';
                $scope.complain.complainStatusId = '';
                $scope.complain.complainStatusText = '';
            };

            $scope.save = function () {
                $scope.complain.complainStatusId = '1';
                console.log($scope.complain)
                $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify($scope.complain),
                    url: '/ComplainApi/Save',
                    success: function (data, status) {
                        $(".save-alert").fadeTo(2000, 500).slideUp(500, function () {
                            $(".save-alert").alert('close');
                        });

                        $('#complainModal').modal('toggle');
                        $scope.clear();
                        $scope.load();
                    },
                    error: function (status) { }
                });
            };

            $scope.delete = function (data) {
                var state = confirm("Do you want to delete this record");
                if (state == true) {
                    $.ajax({
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        //data: "{ id: "+data.id+" }",
                        data: JSON.stringify(data),
                        url: '/ComplainApi/Delete',
                        success: function (status) {
                            $(".delete-alert").fadeTo(2000, 500).slideUp(500, function () {
                                $(".delete-alert").alert('close');
                            });

                            $scope.load();
                        },
                        error: function (status) { }
                    });
                }
            }

            $scope.goToDetail = function (id) {
                window.location = "/Complain/Detail/" + id;
            }

           
        }
    ]);