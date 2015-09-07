app.controller("ExamController", function ($scope, $http) {

    $scope.SelectedExamTypeID = 0;
    $scope.selectedJobId = 0;
    $scope.inputExamDate = "";
    waitCursor();
    $http.get("http://localhost:6161/api/ExamType/").success(function (data) {
        $scope.examTypes = data;
    });
    autoCursor();
    $scope.ChangeExamType = function() {
        console.log($scope.SelectedExamTypeID);
        $scope.applicantList = [];
        waitCursor();
        $http.get("http://localhost:6161/api/Exam").success(function (data) {
            console.log(data);
            $scope.jobs = data;
            $scope.selectedJobId = 0;
        });
        autoCursor();
    };
    $scope.ChangeJob = function () {
        console.log($scope.selectedJobId);
        waitCursor();
        $http.post("http://localhost:6161/api/Exam", JSON.stringify({
            examId: $scope.SelectedExamTypeID,
            jobId: $scope.selectedJobId
        })).success(function (data) {
            console.log(data);
            $scope.applicantList = data;
        });
        autoCursor();
    };
    $scope.SubmitApplicantList = function (applicantList) {
        waitCursor();
        var objApplicant = [];
        angular.forEach(applicantList, function (value, key) {
            if (value.IsSelected) {
                objApplicant.push(new ApplicantModel(value.ApplicantID, value.FirstName, value.LastName, value.MobileNo, value.Email, value.MailingAddress, value.StatusCode, value.ExpertiseCode));
            }
        });
        console.log(objApplicant);
        var objExam = new ExamModel(0, $scope.selectedJobId, $scope.SelectedExamTypeID, $scope.inputExamDate, 0, false);

        $http.post("http://localhost:6161/api/SelectApplicant", JSON.stringify({
            objApplicantInfo: objApplicant,
            objExamInfo: objExam
        })).success(function (data) {
            console.log("Save Applicant Message:" + data);
            window.location.href = "/SelectApplicant/Index";
        });
        autoCursor();
    };
});