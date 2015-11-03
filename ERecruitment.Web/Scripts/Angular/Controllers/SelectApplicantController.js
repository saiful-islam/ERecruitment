app.controller("SelectApplicantController", function ($scope, $http, $location) {

    $scope.examInfoes = { jobid: getParameterByName('jobid'), jobname: getParameterByName('jobname'), examTypeId:0, examDate:"", examTypes :[] , applicantList:[],objApplicant:[], objExam:[]  };

    if ($scope.examInfoes.jobid === "") {
        window.location.href = "/Job/Index";
    }
    $http.get("http://localhost:6161/api/ExamType/" + $scope.examInfoes.jobid).success(function (data) {
        console.log(data);
        $scope.examInfoes.examTypes = data;

    });
    autoCursor();
    $scope.ChangeExamType = function() {
        waitCursor();
        $http.put("http://localhost:6161/api/SelectApplicant",JSON.stringify({
            examTypeId: $scope.examInfoes.examTypeId,
            jobId: $scope.examInfoes.jobid
        })).success(function (data) {
            console.log(data);
            $scope.examInfoes.applicantList = data;
        });
        autoCursor();
    };
    
    $scope.SubmitApplicantList = function (applicantList) {
        waitCursor();
        angular.forEach(applicantList, function (value, key) {
            if (value.IsSelected) {
                $scope.examInfoes.objApplicant.push(new ApplicantModel(value.ApplicantID, value.FirstName, value.LastName, value.MobileNo, value.Email, value.MailingAddress, value.StatusCode, value.ExpertiseCode));
            }
        });
        console.log($scope.examInfoes.objApplicant.length);
        if ($scope.examInfoes.objApplicant.length === 0) {
            alert("Applicants must be selected!!!");
            autoCursor();
            return;
        }
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