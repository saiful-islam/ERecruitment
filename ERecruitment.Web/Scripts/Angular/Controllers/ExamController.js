app.controller("ExamController", function ($scope, $http) {

    $scope.examInfoes = {
        jobid: getParameterByName('jobid'),
        jobname: getParameterByName('jobname'),
        examTypeId: 0,
        examDate: "",
        examType: "  ",
        applicantList: [],
        objExam: []
    };
    $http.get("http://localhost:6161/api/RunningExamTypes/" + $scope.examInfoes.jobid).success(function (data) {
        angular.forEach(data, function (value, key) {
            $scope.examInfoes.examTypeId = value.ExamTypeID;
            $scope.examInfoes.examType = value.ExamType;
        });
        $scope.LoadApplicantList();
    });
    $scope.LoadApplicantList = function () {
        $http.post("http://localhost:6161/api/Exam", JSON.stringify({
            examId: $scope.examInfoes.examTypeId,
            jobId: $scope.examInfoes.jobid
        })).success(function (data) {
            $scope.examInfoes.applicantList = data;
        });
    };
    $scope.SaveExam = function (applicantList, isCompleted) {
        angular.forEach(applicantList, function (value, key) {
            $scope.examInfoes.objExam.push(
                new ExamModel(value.ApplicantID,
                    $scope.examInfoes.jobid,
                    $scope.examInfoes.examTypeId,
                    value.ExamDate,
                    value.Marks,
                    value.IsRejected,
                    isCompleted,
                    value.IsPassed
                ));
        });
        console.log($scope.examInfoes.objExam);
        $http.put("http://localhost:6161/api/Exam", JSON.stringify($scope.examInfoes.objExam)).success(function (data) {
            console.log("Update Exam Message:" + data);
            window.location.href = "/Job/Index";
        });
    };


    //$scope.SubmitApplicantList = function (applicantList) {
    //    var objApplicant = [];
    //    angular.forEach(applicantList, function (value, key) {
    //        if (value.IsSelected) {
    //            objApplicant.push(new ApplicantModel(value.ApplicantID, value.FirstName, value.LastName, value.MobileNo, value.Email, value.MailingAddress, value.StatusCode, value.ExpertiseCode));
    //        }
    //    });
    //    console.log(objApplicant);
    //    var objExam = new ExamModel(0, $scope.selectedJobId, $scope.SelectedExamTypeID, $scope.inputExamDate, 0, false);

    //    $http.post("http://localhost:6161/api/SelectApplicant", JSON.stringify({
    //        objApplicantInfo: objApplicant,
    //        objExamInfo: objExam
    //    })).success(function (data) {
    //        console.log("Save Applicant Message:" + data);
    //        window.location.href = "/SelectApplicant/Index";
    //    });
    //    autoCursor();
    //};
});