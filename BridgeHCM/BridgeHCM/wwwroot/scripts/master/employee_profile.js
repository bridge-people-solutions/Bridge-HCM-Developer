var app = angular.module('myApp', ['ngRoute', 'ngSanitize']);

app.controller('myCtrl', function ($scope) {
    $(".theme-loader").animate({
        opacity: "0"
    }, 1000);
    setTimeout(function () {
        $(".theme-loader").remove();
    }, 1000);

    $scope.submit = function () {
        swal({
            title: "Are you sure?",
            text: "This transaction will be saved!",
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false,
            showLoaderOnConfirm: true
        },
            function (isConfirm) {
                if (isConfirm) {
                    $("#frm_employee_profile").submit();
                } else {
                    swal("Cancelled", "", "error");
                }
            });
    }
});