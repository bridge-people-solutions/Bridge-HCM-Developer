var app = angular.module('myApp', ['ngRoute', 'ngSanitize']);

app.controller('myCtrl', function ($scope, $q, $location, employeeCreateService) {
    $scope.fixSalary = false;
    $scope.tardinessDeduction = false;
    $scope.withoutOT = false;
    $scope.relative_list = [];
    $scope.emergency_list = [];
    $scope.employment_list = [];
    $scope.education_list = [];
    $scope.college_list = [];
    $scope.oldFilename = "/images/default.png";
    var approval = employeeCreateService.dropdownList(1);
    var access = employeeCreateService.dropdownList(2);
    var religion = employeeCreateService.dropdownList(3);
    var nationality = employeeCreateService.dropdownList(4);
    var civil = employeeCreateService.dropdownList(5);
    var status = employeeCreateService.dropdownList(6);
    var occupation = employeeCreateService.dropdownList(7);
    var department = employeeCreateService.dropdownList(8);
    var division = employeeCreateService.dropdownList(9);
    var section = employeeCreateService.dropdownList(10);
    var confidentiality = employeeCreateService.dropdownList(11);
    var salutation = employeeCreateService.dropdownList(12);
    var gender = employeeCreateService.dropdownList(13);
    var relationship = employeeCreateService.dropdownList(14);
    var education = employeeCreateService.dropdownList(15);
    var payroll_type = employeeCreateService.payrollTypeList();
    var warehouse = employeeCreateService.warehouseView();
    var employee = employeeCreateService.employeeList();
    var dd = employeeCreateService.employeeDef(angular.element('.trans').val());
    var ser = employeeCreateService.seriesView();
    $q.all([religion, nationality, civil, status, occupation, department, division
        , section, confidentiality, payroll_type, salutation, warehouse, employee
        , gender, relationship, education, approval, access, dd, ser])
        .then(function (results) {
            $scope.personal = JSON.parse(results[18].data);
            $scope.ddReligion = JSON.parse(results[0].data);
            $scope.ddNationality = JSON.parse(results[1].data);
            $scope.ddCivilStatus = JSON.parse(results[2].data);
            $scope.ddStatus = JSON.parse(results[3].data);
            $scope.ddOccupation = JSON.parse(results[4].data);
            $scope.ddDepartment = JSON.parse(results[5].data);
            $scope.ddDivision = JSON.parse(results[6].data);
            $scope.ddSection = JSON.parse(results[7].data);
            $scope.ddConfidentiality = JSON.parse(results[8].data);
            $scope.ddPayrollType = results[9].data;
            $scope.ddSalutation = JSON.parse(results[10].data);
            $scope.ddWarehouse = JSON.parse(results[11].data);
            $scope.ddEmployee = JSON.parse(results[12].data);
            $scope.ddGender = JSON.parse(results[13].data);
            $scope.ddRelationship = JSON.parse(results[14].data);
            $scope.ddEducation = JSON.parse(results[15].data);
            $scope.ddApprovalGroup = JSON.parse(results[16].data);
            $scope.ddAccessLevel = JSON.parse(results[17].data);
            $scope.employeeCode = JSON.parse(results[19].data).series_code;
            if ($scope.personal.length > 0) {
                console.log($scope.personal[0])
                $scope.selectedSalutation = $scope.personal[0].salutation_id;
                $scope.selectedReligion = $scope.personal[0].religion_id;
                $scope.displayName = $scope.personal[0].display_name;
                $scope.nickName = $scope.personal[0].nick_name;
                $scope.firstName = $scope.personal[0].first_name;
                $scope.middleName = $scope.personal[0].middle_name;
                $scope.lastName = $scope.personal[0].last_name;
                $scope.selectedReligion = $scope.personal[0].religion_id;
                $scope.selectedGender = $scope.personal[0].gender_id;
                $scope.selectedNationality = $scope.personal[0].nationality_id;
                $scope.birthPlace = $scope.personal[0].birth_place;
                $scope.birthDay = new Date($scope.personal[0].birthday);
                $scope.selectedCivilStatus = $scope.personal[0].civil_status_id;
                $scope.height = $scope.personal[0].height;
                $scope.weight = $scope.personal[0].weight;
                $scope.bloodType = $scope.personal[0].blood_type;

                $scope.mobileNumber = $scope.personal[0].phone_mobile;
                $scope.phoneNumber = $scope.personal[0].phone_telephone;
                $scope.officeNumber = $scope.personal[0].phone_office;
                $scope.faxNumber = $scope.personal[0].phone_fax;
                $scope.email = $scope.personal[0].email_address;
                $scope.presentAddress = $scope.personal[0].present_address;
                $scope.permanentAddress = $scope.personal[0].permanent_address;

                $scope.selectedPayrollType = $scope.personal[0].payroll_type;
                $scope.biometricsID = $scope.personal[0].biometrics_id;
                $scope.employeeCode = $scope.personal[0].employee_code;
                $scope.basicSalary = $scope.personal[0].basic_rate;
                $scope.selectedEmployeeStatus = $scope.personal[0].employee_status_id;
                $scope.selectedOccupation = $scope.personal[0].occupation_id;
                $scope.bank = $scope.personal[0].bank;
                $scope.bankAccount = $scope.personal[0].bankaccount;
                $scope.selectedDepartment = $scope.personal[0].department_id;
                $scope.sss = $scope.personal[0].sss;
                $scope.pagibig = $scope.personal[0].pagibig;
                $scope.philhealth = $scope.personal[0].philhealth;
                $scope.tin = $scope.personal[0].tin;
                $scope.nbi = $scope.personal[0].nbi;
                $scope.gsis = $scope.personal[0].gsis;
                $scope.dateHired = new Date($scope.personal[0].date_hired);
                $scope.selectedDivision = $scope.personal[0].division_id;
                $scope.selectedSection = $scope.personal[0].section_id;
                $scope.selectedConfidentiality = $scope.personal[0].confidentiality_id;
                var cont = $scope.personal[0].supervisor == 0 ? "" : $scope.personal[0].supervisor;
                if ($scope.personal[0].supervisor != 0) {
                    $scope.selectedEmployee = $scope.personal[0].supervisor;
                }
                $scope.selectedWarehouse = $scope.personal[0].warehouse;
                $scope.selectedApprovalGroup = $scope.personal[0].approval_group_id;
                $scope.selectedAccessLevel = $scope.personal[0].access_level_id;
                $scope.fixSalary = $scope.personal[0].is_fixed_salary;
                $scope.tardinessDeduction = $scope.personal[0].is_tardiness_deduction;
                $scope.withoutOT = $scope.personal[0].is_without_ot;
                $scope.oldFilename = $scope.personal[0].image_path;
                var relative = employeeCreateService.employeeRel(angular.element('.trans').val());
                var emergency = employeeCreateService.employeeEme(angular.element('.trans').val());
                var employment = employeeCreateService.employeeEmp(angular.element('.trans').val());
                var education = employeeCreateService.employeeEdu(angular.element('.trans').val());
                var college = employeeCreateService.employeeDeg(angular.element('.trans').val());

                $q.all([relative, emergency, employment, education, college])
                    .then(function (dr) {
                        $scope.relative_list = dr[0].data;
                        $scope.emergency_list = dr[1].data;
                        $scope.employment_list = dr[2].data;
                        $scope.education_list = dr[3].data;
                        $scope.college_list = dr[4].data;
                    });
            }
        }).then(function () {
            $(".theme-loader").animate({
                opacity: "0"
            }, 1000);
            setTimeout(function () {
                $(".theme-loader").remove();
            }, 1000);
        });

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

    $scope.addRelatives = function () {
        var flag = true;
        if ($scope.relativeName == undefined || $scope.relativeName == "") {
            $scope.isRelativeName = "text-warning";
            toastr.warning("Please input name.", "Warning");
            flag = false;
        }
        else {
            $scope.isRelativeName = "";
        }
        if ($scope.selectedRelativeRelationship == undefined || $scope.selectedRelativeRelationship == "") {
            $scope.isRelativeRelationship = "text-warning";
            toastr.warning("Please select relationship.", "Warning");
            flag = false;
        }
        else {
            $scope.isRelativeRelationship = "";
        }
        if ($scope.relativeBirthday == undefined || $scope.relativeBirthday == "") {
            $scope.isRelativeBirthday = "text-warning";
            toastr.warning("Please input birthday.", "Warning");
            flag = false;
        }
        else {
            $scope.isRelativeBirthday = "";
        }
        if ($scope.selectedRelativeGender == undefined || $scope.selectedRelativeGender == "") {
            $scope.isRelativeGender = "text-warning";
            toastr.warning("Please select gender.", "Warning");
            flag = false;
        }
        else {
            $scope.isRelativeGender = "";
        }
        if ($scope.relativeOccupation == undefined || $scope.relativeOccupation == "") {
            $scope.isRelativeOccupation = "text-warning";
            toastr.warning("Please input occupation.", "Warning");
            flag = false;
        }
        else {
            $scope.isRelativeOccupation = "";
        }
        if ($scope.relativeCompany == undefined || $scope.relativeCompany == "") {
            $scope.isRelativeCompany = "text-warning";
            toastr.warning("Please input company.", "Warning");
            flag = false;
        }
        else {
            $scope.isRelativeCompany = "";
        }

        if (flag) {
            $scope.relative_list.push({
                name: $scope.relativeName,
                relationship: $scope.selectedRelativeRelationship.description,
                relationship_id: $scope.selectedRelativeRelationship.setting_id_ds,
                birthday: $scope.relativeBirthday.toISOString().slice(0, 10),
                gender: $scope.selectedRelativeGender.description,
                gender_id: $scope.selectedRelativeGender.setting_id_ds,
                occupation: $scope.relativeOccupation,
                company: $scope.relativeCompany,

            });
            $scope.relativeName = "";
            $scope.relativeOccupation = "";
            $scope.relativeCompany = "";
            angular.element('.modal-date').val("");
            angular.element('.modalSelect').val("").select2({ width: '100%' });
            angular.element('#relationshipModal').modal('hide');
        }
    }

    $scope.addEmergency = function () {
        var flag = true;
        if ($scope.emergencyName == undefined || $scope.emergencyName == "") {
            $scope.isEmergencyName = "text-warning";
            toastr.warning("Please input name.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmergencyName = "";
        }
        if ($scope.selectedEmergencyRelationship == undefined || $scope.selectedEmergencyRelationship == "") {
            $scope.isEmergencyRelationship = "text-warning";
            toastr.warning("Please select relationship.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmergencyRelationship = "";
        }
        if ($scope.emergencyAddress == undefined || $scope.emergencyAddress == "") {
            $scope.isEmergencyAddress = "text-warning";
            toastr.warning("Please input address.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmergencyAddress = "";
        }
        if ($scope.emergencyContact == undefined || $scope.emergencyContact == "") {
            $scope.isEmergencyContact = "text-warning";
            toastr.warning("Please input address.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmergencyContact = "";
        }

        if (flag) {
            $scope.emergency_list.push({
                name: $scope.emergencyName,
                relationship: $scope.selectedEmergencyRelationship.description,
                relationship_id: $scope.selectedEmergencyRelationship.setting_id_ds,
                address: $scope.emergencyAddress,
                contact_number: $scope.emergencyContact,
            });
            $scope.emergencyName = "";
            $scope.emergencyAddress = "";
            $scope.emergencyContact = "";
            angular.element('.modalSelect').val("").select2({ width: '100%' });
            angular.element('#emergency').modal('hide');
        }
    }

    $scope.addEmployment = function () {
        var flag = true;
        if ($scope.employmentCompany == undefined || $scope.employmentCompany == "") {
            $scope.isEmploymentCompany = "text-warning";
            toastr.warning("Please input company.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmploymentCompany = "";
        }
        if ($scope.employmentPosition == undefined || $scope.employmentPosition == "") {
            $scope.isEmploymentPosition = "text-warning";
            toastr.warning("Please input position.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmploymentPosition = "";
        }
        if ($scope.employmentSalary == undefined || $scope.employmentSalary == "") {
            $scope.isEmploymentSalary = "text-warning";
            toastr.warning("Please input salary.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmploymentSalary = "";
        }
        if ($scope.employmentFrom == undefined || $scope.employmentFrom == "") {
            $scope.isEmploymentFrom = "text-warning";
            toastr.warning("Please input date from.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmploymentFrom = "";
        }
        if ($scope.employmentTo == undefined || $scope.employmentTo == "") {
            $scope.isEmploymentTo = "text-warning";
            toastr.warning("Please input date to.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmploymentTo = "";
        }
        if ($scope.employmentReason == undefined || $scope.employmentReason == "") {
            $scope.isEmploymentReason = "text-warning";
            toastr.warning("Please input reason for leaving.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmploymentReason = "";
        }

        if (flag) {
            $scope.employment_list.push({
                company: $scope.employmentCompany,
                position: $scope.employmentPosition,
                salary: $scope.employmentSalary,
                date_from: $scope.employmentFrom.toISOString().slice(0, 10),
                date_to: $scope.employmentTo.toISOString().slice(0, 10),
                reason: $scope.employmentReason,
            });

            $scope.employmentCompany = "";
            $scope.employmentPosition = "";
            $scope.employmentSalary = "";
            $scope.employmentReason = "";
            angular.element('.modal-date').val("");
            angular.element('#employmentModal').modal('hide');
        }
    }

    $scope.addEducation = function () {
        var flag = true;
        if ($scope.educationName == undefined || $scope.educationName == "") {
            $scope.isEducationName = "text-warning";
            toastr.warning("Please input name.", "Warning");
            flag = false;
        }
        else {
            $scope.isEducationName = "";
        }
        if ($scope.selectedEducationType == undefined || $scope.selectedEducationType == "") {
            $scope.isSelectedEducationType = "text-warning";
            toastr.warning("Please select type.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedEducationType = "";
        }
        if ($scope.educationFrom == undefined || $scope.educationFrom == "") {
            $scope.isEducationFrom = "text-warning";
            toastr.warning("Please input date from.", "Warning");
            flag = false;
        }
        else {
            $scope.isEducationFrom = "";
        }
        if ($scope.educationTo == undefined || $scope.educationTo == "") {
            $scope.isEducationTo = "text-warning";
            toastr.warning("Please input date to.", "Warning");
            flag = false;
        }
        else {
            $scope.isEducationTo = "";
        }
        if ($scope.educationHonor == undefined || $scope.educationHonor == "") {
            $scope.isEducationHonor = "text-warning";
            toastr.warning("Please input Honors/Awards/Citations.", "Warning");
            flag = false;
        }
        else {
            $scope.isEducationHonor = "";
        }

        if (flag) {
            $scope.education_list.push({
                name: $scope.educationName,
                type: $scope.selectedEducationType.description,
                type_id: $scope.selectedEducationType.setting_id_ds,
                date_from: $scope.educationFrom.toISOString().slice(0, 10),
                date_to: $scope.educationTo.toISOString().slice(0, 10),
                awards: $scope.educationHonor,
            });

            $scope.educationName = "";
            $scope.educationHonor = "";
            angular.element('.modal-date').val("");
            angular.element('.modalSelect').val("").select2({ width: '100%' });
            angular.element('#educationModal').modal('hide');
        }
    }

    $scope.addCollege = function () {
        var flag = true;
        if ($scope.collegeName == undefined || $scope.collegeName == "") {
            $scope.isCollegeName = "text-warning";
            toastr.warning("Please input school.", "Warning");
            flag = false;
        }
        else {
            $scope.isCollegeName = "";
        }
        if ($scope.collegeCourse == undefined || $scope.collegeCourse == "") {
            $scope.isCollegeCourse = "text-warning";
            toastr.warning("Please input course.", "Warning");
            flag = false;
        }
        else {
            $scope.isCollegeCourse = "";
        }
        if ($scope.collegeMajor == undefined || $scope.collegeMajor == "") {
            $scope.isCollegeMajor = "text-warning";
            toastr.warning("Please input course.", "Warning");
            flag = false;
        }
        else {
            $scope.isCollegeMajor = "";
        }

        if (flag) {
            $scope.college_list.push({
                name: $scope.collegeName,
                course: $scope.collegeCourse,
                major: $scope.collegeMajor
            });

            $scope.collegeName = "";
            $scope.collegeCourse = "";
            $scope.collegeMajor = "";
            angular.element('#collegedegreeModal').modal('hide');
        }
    }

    $scope.removeRelatives = function (index) {
        $scope.relative_list.splice(index, 1);
    }

    $scope.removeEmergency = function (index) {
        $scope.emergency_list.splice(index, 1);
    }

    $scope.removeEmployment = function (index) {
        $scope.employment_list.splice(index, 1);
    }

    $scope.removeEducation = function (index) {
        $scope.education_list.splice(index, 1);
    }

    $scope.removeCollege = function (index) {
        $scope.college_list.splice(index, 1);
    }

    function validation() {
        var flag = true;
        //if ($scope.currentFile == undefined) {
        //    $scope.isUpload = "text-warning";
        //    toastr.warning("Please upload picture.", "Warning");
        //    flag = false;
        //}
        //else {
        //    $scope.isUpload = "";
        //}
        if ($scope.selectedSalutation == undefined || $scope.selectedSalutation == "") {
            $scope.isSelectedSalutation = "text-warning";
            toastr.warning("Please select salutation.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedSalutation = "";
        }
        if ($scope.nickName == undefined || $scope.nickName == "") {
            $scope.isNickName = "text-warning";
            toastr.warning("Please input nickname.", "Warning");
            flag = false;
        }
        else {
            $scope.isNickName = "";
        }
        if ($scope.firstName == undefined || $scope.firstName == "") {
            $scope.isFirstName = "text-warning";
            toastr.warning("Please input first name.", "Warning");
            flag = false;
        }
        else {
            $scope.isFirstName = "";
        }
        if ($scope.middleName == undefined || $scope.middleName == "") {
            $scope.isMiddleName = "text-warning";
            toastr.warning("Please input middle name.", "Warning");
            flag = false;
        }
        else {
            $scope.isMiddleName = "";
        }
        if ($scope.lastName == undefined || $scope.lastName == "") {
            $scope.isLastName = "text-warning";
            toastr.warning("Please input last name.", "Warning");
            flag = false;
        }
        else {
            $scope.isLastName = "";
        }
        if ($scope.selectedReligion == undefined || $scope.selectedReligion == "") {
            $scope.isSelectedReligion = "text-warning";
            toastr.warning("Please select religion.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedReligion = "";
        }
        if ($scope.selectedGender == undefined || $scope.selectedGender == "") {
            $scope.isSelectedGender = "text-warning";
            toastr.warning("Please select gender.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedGender = "";
        }
        if ($scope.selectedNationality == undefined || $scope.selectedNationality == "") {
            $scope.isSelectedNationality = "text-warning";
            toastr.warning("Please select nationality.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedNationality = "";
        }
        if ($scope.birthPlace == undefined || $scope.birthPlace == "") {
            $scope.isBirthPlace = "text-warning";
            toastr.warning("Please input birthplace.", "Warning");
            flag = false;
        }
        else {
            $scope.isBirthPlace = "";
        }
        if ($scope.birthDay == undefined || $scope.birthDay == "") {
            $scope.isBirthDay = "text-warning";
            toastr.warning("Please input birthday.", "Warning");
            flag = false;
        }
        else {
            $scope.isBirthDay = "";
        }
        if ($scope.selectedCivilStatus == undefined || $scope.selectedCivilStatus == "") {
            $scope.isSelectedCivilStatus = "text-warning";
            toastr.warning("Please select civil status.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedCivilStatus = "";
        }
        if ($scope.height == undefined || $scope.height == "") {
            $scope.isHeight = "text-warning";
            toastr.warning("Please input height.", "Warning");
            flag = false;
        }
        else {
            $scope.isHeight = "";
        }
        if ($scope.weight == undefined || $scope.weight == "") {
            $scope.isWeight = "text-warning";
            toastr.warning("Please input weight.", "Warning");
            flag = false;
        }
        else {
            $scope.isWeight = "";
        }
        if ($scope.bloodType == undefined || $scope.bloodType == "") {
            $scope.isBloodType = "text-warning";
            toastr.warning("Please input blood type.", "Warning");
            flag = false;
        }
        else {
            $scope.isBloodType = "";
        }
        if ($scope.mobileNumber == undefined || $scope.mobileNumber == "") {
            $scope.isMobileNumber = "text-warning";
            toastr.warning("Please input mobile number.", "Warning");
            flag = false;
        }
        else {
            $scope.isMobileNumber = "";
        }
        if ($scope.phoneNumber == undefined || $scope.phoneNumber == "") {
            $scope.isPhoneNumber = "text-warning";
            toastr.warning("Please input phone number.", "Warning");
            flag = false;
        }
        else {
            $scope.isPhoneNumber = "";
        }
        if ($scope.officeNumber == undefined || $scope.officeNumber == "") {
            $scope.isOfficeNumber = "text-warning";
            toastr.warning("Please input office number.", "Warning");
            flag = false;
        }
        else {
            $scope.isOfficeNumber = "";
        }
        if ($scope.faxNumber == undefined || $scope.faxNumber == "") {
            $scope.isFaxNumber = "text-warning";
            toastr.warning("Please input fax number.", "Warning");
            flag = false;
        }
        else {
            $scope.isFaxNumber = "";
        }
        if ($scope.email == undefined || $scope.email == "") {
            $scope.isEmail = "text-warning";
            toastr.warning("Please input email.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmail = "";
        }
        if ($scope.presentAddress == undefined || $scope.presentAddress == "") {
            $scope.isPresentAddress = "text-warning";
            toastr.warning("Please input present address.", "Warning");
            flag = false;
        }
        else {
            $scope.isPresentAddress = "";
        }
        if ($scope.permanentAddress == undefined || $scope.permanentAddress == "") {
            $scope.isPermanentAddress = "text-warning";
            toastr.warning("Please input permanent address.", "Warning");
            flag = false;
        }
        else {
            $scope.isPermanentAddress = "";
        }

        if ($scope.selectedPayrollType == undefined || $scope.selectedPayrollType == "") {
            $scope.isSelectedPayrollType = "text-warning";
            toastr.warning("Please select payroll type.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedPayrollType = "";
        }
        if ($scope.biometricsID == undefined || $scope.biometricsID == "") {
            $scope.isBiometricsID = "text-warning";
            toastr.warning("Please input biometrics Id.", "Warning");
            flag = false;
        }
        else {
            $scope.isBiometricsID = "";
        }
        if ($scope.employeeCode == undefined || $scope.employeeCode == "") {
            $scope.isEmployeeCode = "text-warning";
            toastr.warning("Please input employee code.", "Warning");
            flag = false;
        }
        else {
            $scope.isEmployeeCode = "";
        }
        if ($scope.basicSalary == undefined || $scope.basicSalary == "") {
            $scope.isBasicSalary = "text-warning";
            toastr.warning("Please input basic salary.", "Warning");
            flag = false;
        }
        else {
            $scope.isBasicSalary = "";
        }
        if ($scope.selectedEmployeeStatus == undefined || $scope.selectedEmployeeStatus == "") {
            $scope.isSelectedEmployeeStatus = "text-warning";
            toastr.warning("Please select employee status.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedEmployeeStatus = "";
        }
        if ($scope.selectedOccupation == undefined || $scope.selectedOccupation == "") {
            $scope.isSelectedOccupation = "text-warning";
            toastr.warning("Please select occupation.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedOccupation = "";
        }
        if ($scope.bank == undefined || $scope.bank == "") {
            $scope.isBank = "text-warning";
            toastr.warning("Please input bank.", "Warning");
            flag = false;
        }
        else {
            $scope.isBank = "";
        }
        if ($scope.bankAccount == undefined || $scope.bankAccount == "") {
            $scope.isBankAccount = "text-warning";
            toastr.warning("Please input bank account.", "Warning");
            flag = false;
        }
        else {
            $scope.isBankAccount = "";
        }
        if ($scope.selectedDepartment == undefined || $scope.selectedDepartment == "") {
            $scope.isSelectedDepartment = "text-warning";
            toastr.warning("Please select department.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedDepartment = "";
        }
        if ($scope.sss == undefined || $scope.sss == "") {
            $scope.isSss = "text-warning";
            toastr.warning("Please input SSS.", "Warning");
            flag = false;
        }
        else {
            $scope.isSss = "";
        }
        if ($scope.pagibig == undefined || $scope.pagibig == "") {
            $scope.isPagibig = "text-warning";
            toastr.warning("Please input pagibig.", "Warning");
            flag = false;
        }
        else {
            $scope.isPagibig = "";
        }
        if ($scope.philhealth == undefined || $scope.philhealth == "") {
            $scope.isPhilhealth = "text-warning";
            toastr.warning("Please input philhealth.", "Warning");
            flag = false;
        }
        else {
            $scope.isPhilhealth = "";
        }
        if ($scope.tin == undefined || $scope.tin == "") {
            $scope.isTin = "text-warning";
            toastr.warning("Please input tin.", "Warning");
            flag = false;
        }
        else {
            $scope.isTin = "";
        }
        if ($scope.nbi == undefined || $scope.nbi == "") {
            $scope.isNbi = "text-warning";
            toastr.warning("Please input nbi.", "Warning");
            flag = false;
        }
        else {
            $scope.isNbi = "";
        }
        if ($scope.gsis == undefined || $scope.gsis == "") {
            $scope.isGsis = "text-warning";
            toastr.warning("Please input gsis.", "Warning");
            flag = false;
        }
        else {
            $scope.isGsis = "";
        }
        if ($scope.dateHired == undefined || $scope.dateHired == "") {
            $scope.isDateHired = "text-warning";
            toastr.warning("Please input date hired.", "Warning");
            flag = false;
        }
        else {
            $scope.isDateHired = "";
        }
        if ($scope.selectedDivision == undefined || $scope.selectedDivision == "") {
            $scope.isSelectedDivision = "text-warning";
            toastr.warning("Please select division.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedDivision = "";
        }
        if ($scope.selectedSection == undefined || $scope.selectedSection == "") {
            $scope.isSelectedSection = "text-warning";
            toastr.warning("Please select section.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedSection = "";
        }
        if ($scope.selectedConfidentiality == undefined || $scope.selectedConfidentiality == "") {
            $scope.isSelectedConfidentiality = "text-warning";
            toastr.warning("Please select confidentiality.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedConfidentiality = "";
        }
        //if ($scope.selectedEmployee == undefined || $scope.selectedEmployee == "") {
        //    $scope.isSelectedEmployee = "text-warning";
        //    toastr.warning("Please select immediate supervisor.", "Warning");
        //    flag = false;
        //}
        //else {
        //    $scope.isSelectedEmployee = "";
        //}
        if ($scope.selectedWarehouse == undefined || $scope.selectedWarehouse == "") {
            $scope.isSelectedWarehouse = "text-warning";
            toastr.warning("Please select warehouse.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedWarehouse = "";
        }
        if ($scope.selectedApprovalGroup == undefined || $scope.selectedApprovalGroup == "") {
            $scope.isSelectedApprovalGroup = "text-warning";
            toastr.warning("Please select approval group.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedApprovalGroup = "";
        }
        if ($scope.selectedAccessLevel == undefined || $scope.selectedAccessLevel == "") {
            $scope.isSelectedAccessLevel = "text-warning";
            toastr.warning("Please select access level.", "Warning");
            flag = false;
        }
        else {
            $scope.isSelectedAccessLevel = "";
        }

        return flag;
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
                        var oldPath = false;
                        var path = "";
                        if ($scope.currentFile != undefined) {
                            path = $scope.currentFile.name;
                            oldPath = false;
                        }
                        else {
                            path = $scope.oldFilename;
                            oldPath = true;
                        }
                        $scope.personal_info = {
                            employee_id: angular.element('.trans').val(),
                            employee_code: $scope.employeeCode,
                            username: "",
                            userhash: "",
                            salutation_id: $scope.selectedSalutation,
                            first_name: $scope.firstName,
                            middle_name: $scope.middleName,
                            last_name: $scope.lastName,
                            display_name: $scope.displayName,
                            nick_name: $scope.nickName,
                            religion_id: $scope.selectedReligion,
                            gender_id: $scope.selectedGender,
                            nationality_id: $scope.selectedNationality,
                            birth_place: $scope.birthPlace,
                            birthday: $scope.birthDay.toISOString().slice(0, 10),
                            civil_status_id: $scope.selectedCivilStatus,
                            height: $scope.height,
                            weight: $scope.weight,
                            blood_type: $scope.bloodType,
                            phone_mobile: $scope.mobileNumber,
                            phone_telephone: $scope.phoneNumber,
                            phone_office: $scope.officeNumber,
                            phone_fax: $scope.faxNumber,
                            email_address: $scope.email,
                            present_address: $scope.presentAddress,
                            permanent_address: $scope.permanentAddress,
                            image_path: path,
                            //question1: 0,
                            //answer1: "",
                            //question2: 0,
                            //answer2: "",
                            active: true,
                            approval_group_id: $scope.selectedApprovalGroup,
                            access_level_id: $scope.selectedAccessLevel,
                            immediate_supervisor_id: $scope.selectedEmployee,
                        };
                        $scope.payroll_info = {
                            payroll_type: $scope.selectedPayrollType,
                            biometrics_id: $scope.biometricsID,
                            bank: $scope.bank,
                            bankaccount: $scope.bankAccount,
                            basic_rate: $scope.basicSalary,
                            employee_status_id: $scope.selectedEmployeeStatus,
                            occupation_id: $scope.selectedOccupation,
                            department_id: $scope.selectedDepartment,
                            sss: $scope.sss,
                            pagibig: $scope.pagibig,
                            philhealth: $scope.philhealth,
                            tin: $scope.tin,
                            nbi: $scope.nbi,
                            gsis: $scope.gsis,
                            date_hired: $scope.dateHired.toISOString().slice(0, 10),
                            division_id: $scope.selectedDivision,
                            section_id: $scope.selectedSection,
                            confidentiality: $scope.selectedConfidentiality,
                            supervisor: $scope.selectedEmployee,
                            warehouse: $scope.selectedWarehouse,
                            is_fixed_salary: $scope.fixSalary,
                            is_tardiness_deduction: $scope.tardinessDeduction,
                            is_without_ot: $scope.withoutOT
                        };
                        employeeCreateService.employeeAdd(
                            $scope.personal_info,
                            $scope.payroll_info,
                            $scope.relative_list,
                            $scope.emergency_list,
                            $scope.employment_list,
                            $scope.education_list,
                            $scope.college_list,
                            oldPath);
                    } else {
                        swal("Cancelled", "", "error");
                    }
                });
        }
    }
});