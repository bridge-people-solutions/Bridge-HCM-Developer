var app = angular.module('myApp', ['ngRoute', 'ngSanitize']);

app.controller('myCtrl', function ($scope, warehouseService) {
    $(".theme-loader").animate({
        opacity: "0"
    }, 1000);
    setTimeout(function () {
        $(".theme-loader").remove();
    }, 1000);

    $scope.swtActive = true;
    $scope.setFile = function (element) {
        $scope.currentFile = element.files[0];
        var reader = new FileReader();

        if ($scope.currentFile.size / 1024 < 2000) {
            reader.onload = function (event) {
                $scope.image_source = event.target.result
                $scope.$apply()
            }
            reader.readAsDataURL(element.files[0]);
        }
    }

    $scope.submit = function () {
        var flag = validation();
        if (flag) {
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
                        warehouseService.warehouseAdd(
                            0,
                            $scope.currentFile.name,
                            $scope.name,
                            $scope.description,
                            $scope.tin,
                            $scope.phone,
                            $scope.fax,
                            $scope.email,
                            $scope.address,
                            $scope.swtActive);
                    } else {
                        swal("Cancelled", "", "error");
                    }
                });
        }
    }

    function validation() {
        var ret = true;
        if ($scope.currentFile == undefined) {
            toastr.warning("Please upload picture.", "Warning");
            ret = false;
        }
        if ($scope.name === undefined || $scope.name === "") {
            $scope.isName = "text-warning";
            toastr.warning("Please input name.", "Warning");
            ret = false;
        }
        else {
            $scope.isName = "";
        }
        if ($scope.description === undefined || $scope.description === "") {
            $scope.isDescription = "text-warning";
            toastr.warning("Please input description.", "Warning");
            ret = false;
        }
        else {
            $scope.isDescription = "";
        }
        if ($scope.tin === undefined || $scope.tin === "") {
            $scope.isTin = "text-warning";
            toastr.warning("Please input tin.", "Warning");
            ret = false;
        }
        else {
            $scope.isTin = "";
        }
        if ($scope.phone === undefined || $scope.phone === "") {
            $scope.isPhone = "text-warning";
            toastr.warning("Please input phone.", "Warning");
            ret = false;
        }
        else {
            $scope.isPhone = "";
        }
        if ($scope.fax === undefined || $scope.fax === "") {
            $scope.isFax = "text-warning";
            toastr.warning("Please input fax.", "Warning");
            ret = false;
        }
        else {
            $scope.isFax = "";
        }
        if ($scope.email === undefined || $scope.email === "") {
            $scope.isEmail = "text-warning";
            toastr.warning("Please input email.", "Warning");
            ret = false;
        }
        else {
            $scope.isEmail = "";
        }
        if ($scope.address === undefined || $scope.address === "") {
            $scope.isAddress = "text-warning";
            toastr.warning("Please input address.", "Warning");
            ret = false;
        }
        else {
            $scope.isAddress = "";
        }
        return ret;
    }
});