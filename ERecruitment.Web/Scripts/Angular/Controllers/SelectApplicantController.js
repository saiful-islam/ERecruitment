app.controller("SelectApplicantController", function ($scope, $http, $location) {

    console.log(getParameterByName('jobname'));
    $scope.examInfoes = { jobid: getParameterByName('jobid'), jobname: getParameterByName('jobname'), examTypeId:0, examDate:"", examTypes :[] , applicantList:[],objApplicant:[], objExam:[]  };

    $http.get("http://localhost:6161/api/ExamType/").success(function (data) {
        $scope.examInfoes.examTypes = data;
    });
    autoCursor();
    $scope.ChangeExamType = function() {
        waitCursor();
        $http.get("http://localhost:6161/api/SelectApplicant/" + $scope.examInfoes.examTypeId).success(function (data) {
            console.log(data);
            console.log($scope.examInfoes.examTypeId);
            $scope.examInfoes.applicantList = data;
        });
        autoCursor();
    };
    //$scope.ChangeJob = function () {
    //    waitCursor();
    //    $http.get("http://localhost:6161/api/SelectApplicant/" + $scope.SelectedExamTypeID).success(function (data) {
    //        $scope.examInfoes.applicantList = data;
    //    });
    //    autoCursor();
    //};
    $scope.SubmitApplicantList = function (applicantList) {
        waitCursor();
        angular.forEach(applicantList, function (value, key) {
            if (value.IsSelected) {
                $scope.examInfoes.objApplicant.push(new ApplicantModel(value.ApplicantID, value.FirstName, value.LastName, value.MobileNo, value.Email, value.MailingAddress, value.StatusCode, value.ExpertiseCode));
            }
        });
        $scope.examInfoes.objExam = new ExamModel(0, $scope.examInfoes.jobid, $scope.examInfoes.examTypeId, $scope.examInfoes.examDate, 0, false);

        $http.post("http://localhost:6161/api/SelectApplicant", JSON.stringify({
            objApplicantInfo: $scope.examInfoes.objApplicant,
            objExamInfo: $scope.examInfoes.objExam
        })).success(function (data) {
            console.log("Save Applicant Message:" + data);
            window.location.href = "/SelectApplicant/Index";
        });
        autoCursor();
    };
});