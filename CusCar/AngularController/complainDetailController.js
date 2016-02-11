
angular
    .module('CusCar.ctrl.complain', [])
    .controller('complainDetailController', [
        '$scope', function ($scope) {

            $scope.complainList = [];
            $scope.complainDetailList = [];
            $scope.complainStatusList = [];
            $scope.userStatus;

            $(".save-alert").hide();

            $scope.load;
            $scope.loadDetail;
            $scope.loadComplainStatusList;
            $scope.getUserStatus;

            $scope.load = function () {
                var segment_str = window.location.pathname; // return segment1/segment2/segment3/segment4
                var segment_array = segment_str.split('/');
                var last_segment = segment_array[segment_array.length - 1];
                
                $.ajax({
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    data: { "complainId" : last_segment },
                    url: '/ComplainApi/GetDetail',
                    success: function (data) {
                        $scope.complainList = data
                        $scope.$apply();
                    }
                });                
            }

            $scope.loadDetail = function () {
                var segment_str = window.location.pathname; // return segment1/segment2/segment3/segment4
                var segment_array = segment_str.split('/');
                var last_segment = segment_array[segment_array.length - 1];

                $.ajax({
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    data: { "complainId": last_segment },
                    url: '/ComplainApi/GetComplainDetailList',
                    success: function (data) {
                        $scope.complainDetailList = data
                        $scope.$apply();
                    }
                });
            }

            $scope.loadComplainStatusList = function ()
            {
                $.ajax({
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    url: '/ComplainApi/GetComplainStatusList',
                    success: function (data) {
                        $scope.complainStatusList = data
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
            $scope.loadDetail();
            $scope.loadComplainStatusList();
            $scope.getUserStatus();

            $scope.complain = {
                complainId: '',
                complainSubject: '',
                complainText: '',
                complainStatus: '',
                userId: '',
                username: ''
            }

            $scope.clear = function () {
                $scope.complain.complainId = '';
                $scope.complain.complainSubject = '';
                $scope.complain.complainText = '';
                $scope.complain.complainStatus = '';
                $scope.complain.userId = '';
                $scope.complain.username = '';
            };

            $scope.clearReply = function () {
                $scope.complainDetail.complainDetailText = '';
            };

            $scope.postReply = function ($event) {

                var keyCode = $event.which || $event.keyCode;

                if (keyCode == 13) {
                    var segment_str = window.location.pathname; // return segment1/segment2/segment3/segment4
                    var segment_array = segment_str.split('/');
                    var last_segment = segment_array[segment_array.length - 1];

                    $scope.complainDetail.complainId = last_segment;
                    $.ajax({
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify($scope.complainDetail),
                        url: '/ComplainApi/PostReply',
                        success: function (data, status) {
                            $(".save-alert").fadeTo(2000, 500).slideUp(500, function () {
                                $(".save-alert").alert('close');
                            });

                            $scope.clearReply();
                            $scope.load();
                            $scope.loadDetail();
                        },
                        error: function (status) { }
                    });
                }
            };

            $scope.changeComplainStatus = function () {
                var segment_str = window.location.pathname; // return segment1/segment2/segment3/segment4
                var segment_array = segment_str.split('/');
                var last_segment = segment_array[segment_array.length - 1];

                $scope.complainRecord.complainId = last_segment;
                $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify($scope.complainRecord),
                    url: '/ComplainApi/ChangeComplainStatus',
                    success: function (data, status) {
                        $scope.load();
                        $scope.loadDetail();
                    },
                    error: function (status) { }
                });
            }

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
                            console.log(status)
                            $scope.load();
                        },
                        error: function (status) { }
                    });
                }
            }

            $scope.edit = function (index) {
                $scope.complain.complainId = index.complainId;
                $scope.complain.complainSubject = index.complainSubject;
                $scope.complain.complainText = index.complainText;
                $scope.complain.complainStatus = index.complainStatus;
            };

            $scope.update = function () {
                $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify($scope.emp),
                    url: '/api/ComplainApi/',
                    success: function (data, status) {
                        console.log(data)
                        $scope.clear();
                        $scope.load();
                    },
                    error: function (status) { }
                });
            };
        }
    ]);