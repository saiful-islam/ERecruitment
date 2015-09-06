app.controller("ApplicantController", function($scope, $http) {
    $scope.checked = false;
    $scope.checkedCareer = false;
    $scope.checkedProject = false;
    $scope.checkedEducation = false;
    $scope.checkedSkill = false;
    $scope.selectedStatus = "";
    $scope.selectedExpertise = "";
    $scope.inputFirstName = "";
    $scope.inputLastName = "";
    $scope.inputMobileNo = "";
    $scope.inputEmail = "";
    $scope.inputMailingAddress = "";
    $scope.selectedStatus = "";
    $scope.selectExpertise = "";
    $scope.editedApplicantId = 0;

    $scope.showApplicantList = true;
    $scope.showCreateApplicant = false;
    $scope.showEditbtn = false;

    $scope.CreateApplicant = function() {
        $scope.showApplicantList = false;
        $scope.showCreateApplicant = true;

        $scope.checked = false;
        $scope.checkedCareer = false;
        $scope.checkedProject = false;
        $scope.checkedEducation = false;
        $scope.checkedSkill = false;
        $scope.selectedStatus = "";
        $scope.selectedExpertise = "";
        $scope.inputFirstName = "";
        $scope.inputLastName = "";
        $scope.inputMobileNo = "";
        $scope.inputEmail = "";
        $scope.inputMailingAddress = "";
        $scope.selectedStatus = "";
        $scope.selectExpertise = "";

        $scope.careers = [];
        $scope.careers.push(new CareerModel(0, 0, "", "", "", "", "", ""));

        $scope.projects = [];
        $scope.projects.push(new ProjectThesisModel(0, 0, "", "", "", "", "", false));

        $scope.educations = [];
        $scope.educations.push(new EducationModel(0, 0, 0, "", "", "", false));

        $scope.skills = [];
        $scope.skills.push(new SkillHistoryModel(0, 0, false));

        $scope.showEditbtn = false;
    };

    $scope.BackApplicantList = function () {
        $scope.showApplicantList = true;
        $scope.showCreateApplicant = false;
    };

    $http.get("http://localhost:6161/api/Status").success(function (data) {
        $scope.statuses = data;
    });
    $http.get("http://localhost:6161/api/Expertise").success(function (data) {
        $scope.expertises = data;
    });
    $http.get("http://localhost:6161/api/Education").success(function (data) {
        $scope.educationNames = data;
    });
    $http.get("http://localhost:6161/api/Institute").success(function (data) {
        $scope.institutes = data;
    });
    $http.get("http://localhost:6161/api/Applicant").success(function (data) {
        $scope.applicantList = data;
        console.log(data);
    });
    $http.get("http://localhost:6161/api/Skill").success(function (data) {
        $scope.skillNames = data;
    });

    $scope.careers = [];
    $scope.careers.push(new CareerModel(0, 0, "", "", "", "", "", ""));

    $scope.projects = [];
    $scope.projects.push(new ProjectThesisModel(0, 0, "", "", "", "", "", false));

    $scope.educations = [];
    $scope.educations.push(new EducationModel(0, 0, 0, "", "", "", false));

    $scope.skills = [];
    $scope.skills.push(new SkillHistoryModel(0, 0, false));

    $scope.SaveApplicantInfo = function () {
        waitCursor();
        var objApplicant = new ApplicantModel(0, $scope.inputFirstName, $scope.inputLastName, $scope.inputMobileNo
                                            , $scope.inputEmail, $scope.inputMailingAddress, $scope.selectedStatus
                                            ,$scope.selectedExpertise);
        console.log(objApplicant);
        $http.post("http://localhost:6161/api/Applicant", JSON.stringify({
            objApplicantInfo: objApplicant,
            objCareerInfo: $scope.careers,
            objProjectThesisInfo: $scope.projects,
            objEducation: $scope.educations,
            objSkill: $scope.skills
        })).success(function (data) {
            console.log("Save Applicant Message:" + data);
            autoCursor();
            window.location.href = "/Applicant/Index";
        });

    };
    $scope.AddCarrerInfo = function () {
        $scope.careers.push(new CareerModel(0, 0, "", "", "", "", "", ""));
    };
    $scope.RemoveCarrerInfo = function () {
        $scope.careers.splice($scope.careers.length - 1);
    };
    $scope.AddProjectInfo = function () {
        $scope.projects.push(new ProjectThesisModel(0, 0, "", "", "", "", "", false));
    };
    $scope.RemoveProjectInfo = function () {
        $scope.projects.splice($scope.projects.length - 1);
    };
    $scope.AddEducationInfo = function () {
        $scope.educations.push(new EducationModel(0, 0, 0, "", "", "", false));
    };
    $scope.RemoveEducationInfo = function () {
        $scope.educations.splice($scope.educations.length - 1);
    };
    $scope.AddSkill = function () {
        $scope.skills.push(new SkillHistoryModel(0, 0, false));
    };
    $scope.RemoveSkill = function () {
        $scope.skills.splice($scope.skills.length - 1);
    };
    $scope.EditApplicantInfo = function (applicantId) {
        $http.get("http://localhost:6161/api/Applicant/" + applicantId+"").success(function (data) {
            console.log(data);
            $scope.editedApplicantId = applicantId;
            $scope.inputFirstName = data[0].FirstName;
            $scope.inputLastName = data[0].LastName;
            $scope.inputMobileNo = data[0].MobileNo;
            $scope.inputEmail = data[0].Email;
            $scope.inputMailingAddress = data[0].MailingAddress;
            $scope.selectedStatus = data[0].StatusCode;
            $scope.selectedExpertise = data[0].ExpertiseCode;
            $http.get("http://localhost:6161/api/CareerInfo/" + applicantId + "").success(function (data) {
                $scope.careers = data;
            });
            $http.get("http://localhost:6161/api/ProjectThesisInfo/" + applicantId + "").success(function (data) {
                $scope.projects = data;
            });
            $http.get("http://localhost:6161/api/EducationHistory/" + applicantId + "").success(function (data) {
                $scope.educations = data;
            });
            $http.get("http://localhost:6161/api/SkillHistory/" + applicantId + "").success(function (data) {
                $scope.skills = data;
            });
            $scope.showApplicantList = false;
            $scope.showCreateApplicant = true;
            $scope.showEditbtn = true;

        });
        
    };
    $scope.DeleteApplicantInfo = function (applicantId) {
        console.log(applicantId);
    };
    $scope.DeleteApplicantInfo = function (applicantId) {
        console.log(applicantId);
    };
    $scope.UpdateApplicantInfo = function () {
        waitCursor();
        var objApplicant = new ApplicantModel($scope.editedApplicantId, $scope.inputFirstName, $scope.inputLastName, $scope.inputMobileNo
                                            , $scope.inputEmail, $scope.inputMailingAddress, $scope.selectedStatus
                                            , $scope.selectedExpertise);
        console.log(objApplicant);
        $http.put("http://localhost:6161/api/Applicant", JSON.stringify({
            objApplicantInfo: objApplicant,
            objCareerInfo: $scope.careers,
            objProjectThesisInfo: $scope.projects,
            objEducation: $scope.educations,
            objSkill: $scope.skills
        })).success(function (data) {
            console.log("Update Applicant Message:" + data);
            autoCursor();
            window.location.href = "/Applicant/Index";
        });
    };
});