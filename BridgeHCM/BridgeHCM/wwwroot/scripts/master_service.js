app.service('employeeCreateService', ['$http', function ($http) {
    this.dropdownList = function (id) {
        return $http({
            method: "GET",
            url: '/admin/util_dropdown_view',
            params: {
                id: id,
                active: true
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.payrollTypeList = function (id) {
        return $http({
            method: "GET",
            url: '/master/payroll_type_view',
            params: {
                payroll_type_id: 0
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employeeList = function (id) {
        return $http({
            method: "GET",
            url: '/master/employee_list_view',
            params: {
                employee_id: id,
                active: false,
                approved: false
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.warehouseView = function () {
        return $http({
            method: "GET",
            url: '/admin/warehouse_view',
            params: {
                warehouse_id: 0,
                is_active: true,
                is_ap: true
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employeeAdd = function (objPersonal, objPayroll, objRelative, objEmergency, objEmployment, objEducation, objDegree, oldPath) {
        var objHeader = {
            objPersonal: objPersonal,
            objPayroll: objPayroll,
            objRelative: objRelative,
            objEmergency: objEmergency,
            objEmployment: objEmployment,
            objEducation: objEducation,
            objDegree: objDegree,
            oldPath: oldPath
        };
        $.ajax({
            url: '/master/employee_in_up',
            data: objHeader,
            type: 'POST',
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() },
            success: function (result) {
                if (result.employee_id == 0) {
                    swal("Error", "Error upon saving transaction", "error");
                }
                else {
                    swal("Success!", "Employee has been saved.", "success");
                    $(".trans").val(result.employee_id);
                    if (oldPath == false) {
                        var fileData = new FormData();
                        var fileUpload = $("#trigger").get(0);
                        var files = fileUpload.files;
                        for (var x = 0; x < files.length; x++) {
                            fileData.append(files[x].name, files[x]);
                        }

                        $.ajax({
                            url: "/admin/Upload?folder=employee&module=" + $("#module").val() + "&transaction=" + $(".employee_id").val(),
                            data: fileData,
                            type: 'POST',
                            contentType: false,
                            processData: false,
                            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() },
                            success: function (result) {
                                if (result == 0) {
                                    swal("Error", "Error uploading file", "error");
                                }
                            },
                            error: function (errormessage) {
                                swal("Error", "Error upon uploading file", "error");
                            }
                        });
                    }
                }
            },
            error: function (errormessage) {
                swal("Error", "Error upon saving transaction", "error");
            }
        });
    };
    this.employeeDef = function (id) {
        return $http({
            method: "GET",
            url: '/master/employee_sel',
            params: {
                employee_id: id,
                active: false,
                approved: false
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employeeRel = function (id) {
        return $http({
            method: "GET",
            url: '/master/employee_relative_view',
            params: {
                employee_id: id
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employeeEme = function (id) {
        return $http({
            method: "GET",
            url: '/master/employee_emergency_view',
            params: {
                employee_id: id
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employeeEmp = function (id) {
        return $http({
            method: "GET",
            url: '/master/employee_employment_view',
            params: {
                employee_id: id
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employeeEdu = function (id) {
        return $http({
            method: "GET",
            url: '/master/employee_education_view',
            params: {
                employee_id: id
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employeeDeg = function (id) {
        return $http({
            method: "GET",
            url: '/master/employee_degree_view',
            params: {
                employee_id: id
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.seriesView = function () {
        return $http({
            method: "GET",
            url: '/admin/series_view',
            params: {
                module_id: 11,
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
}]);

app.service('employeeListService', ['$http', function ($http) {
    this.employeeFetch = function (index) {
        return $http({
            method: "GET",
            url: '/master/employee_fetch_view',
            params: {
                employee_id: 0,
                row: 40,
                index: index
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employeeList = function () {
        return $http({
            method: "GET",
            url: '/master/employee_list_view',
            params: {
                employee_id: 0,
                active: false,
                approved: false
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
    this.employee_search = function (search) {
        return $http({
            method: "GET",
            url: '/master/employee_search',
            params: {
                search: search
            },
            headers: { 'RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val() }
        })
            .then(function (data) {
                return data;
            })
    };
}]);