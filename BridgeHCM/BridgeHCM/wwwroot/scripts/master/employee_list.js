var app = angular.module('myApp', ['ngRoute', 'ngSanitize']);

app.controller('myCtrl', function ($scope, $q, employeeListService) {
    var index = 1;

    var fetch = employeeListService.employeeFetch(index);
    var list = employeeListService.employeeList();

    $q.all([fetch, list])
        .then(function (results) {
            $scope.employeeFetch = JSON.parse(results[0].data);
            //$scope.employeeList = JSON.parse(results[1].data);

            $('.table').dataTable({
                "destroy": true,
                "aaData": JSON.parse(results[1].data),
                "aoColumns": [
                    { "mDataProp": "display_name" },
                    { "mDataProp": "occupation" },
                    { "mDataProp": "department" },
                    { "mDataProp": "date_hired" },
                    { "mDataProp": "payroll_type_desc" },
                    { "mDataProp": "confidentiality" },
                    { "mDataProp": "button" },
                ],
                "searching": false,
                "lengthChange": false
            });
        }).then(function () {
            $(".theme-loader").animate({
                opacity: "0"
            }, 1000);
            setTimeout(function () {
                $(".theme-loader").remove();
            }, 1000);
        });

    var toggle = true;
    $scope.list = "d-none";
    $scope.tab = function () {
        if (toggle) {
            //$(".thumb-employee").addClass("animated zoomOut")
            $scope.thumb = "d-none";
            $scope.list = "animated zoomIn";
            toggle = false;
        }
        else {
            $scope.thumb = "animated zoomIn";
            $scope.list = "d-none";
            toggle = true;
        }

    }

    $scope.loadSearch = function () {
        var dt = employeeListService.employee_search($scope.search);
        dt.then(function (data) {
            $scope.employeeFetch = JSON.parse(data.data);
            //$scope.employeeList = JSON.parse(data.data);
            $('.table').dataTable({
                "destroy": true,
                "aaData": JSON.parse(data.data),
                "aoColumns": [
                    { "mDataProp": "display_name" },
                    { "mDataProp": "occupation" },
                    { "mDataProp": "department" },
                    { "mDataProp": "date_hired" },
                    { "mDataProp": "payroll_type_desc" },
                    { "mDataProp": "confidentiality" },
                    { "mDataProp": "button" },
                ],
                "searching": false,
                "lengthChange": false
            });
        });
    }

    $scope.thumbList = function () {

    }

    //function indexEmployee() {

    //}

    //angular.element(document).ready(function () {
    //    $(window).scroll(function () {
    //        if ($(window).scrollTop() + $(window).height() > $(document).height() - 100) {
    //            indexEmployee()
    //        }
    //    });
    //});
});
