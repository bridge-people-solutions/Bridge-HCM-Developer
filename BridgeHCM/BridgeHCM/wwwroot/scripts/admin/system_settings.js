var app = angular.module('myApp', ['ngRoute', 'ngSanitize']);

app.controller('myCtrl', function ($scope, systemSettingsService) {
    var dt = systemSettingsService.dropdownList();
    $scope.tableList = [];
    dt.then(function (data) {
        $scope.dropdownlist = JSON.parse(data.data);
        $scope.selected = { value: $scope.dropdownlist[0] };
    }).then(function () {
        $(".theme-loader").animate({
            opacity: "0"
        }, 1000);
        setTimeout(function () {
            $(".theme-loader").remove();
        }, 1000);
    });

    $scope.change = function () {
       var dv = systemSettingsService.dropdownView($scope.selectedDropdown);
        dv.then(function (data) {
            $scope.tableList = JSON.parse(data.data);
        })
    }

    $scope.update_setting = function (index) {
        var cont = $scope.tableList[index].active_ds;
        systemSettingsService.dropdownUp(
            $scope.tableList[index].setting_id_ds,
            cont);
    }

    $scope.submit = function () {
        swal({
            title: "Are you sure?",
            text: "This transaction will be saved!",
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false
        },
            function (isConfirm) {
                if (isConfirm) {
                    var dv = systemSettingsService.dropdownAdd(
                        $scope.selectedDropdown,
                        $scope.description);

                    dv.then(function (data) {
                        $scope.tableList = data.data;
                    });

                    $scope.description = "";
                    swal("Success!", "Dropdown has been added.", "success");

                } else {
                    swal("Cancelled", "", "error");
                }
            });
    }
});