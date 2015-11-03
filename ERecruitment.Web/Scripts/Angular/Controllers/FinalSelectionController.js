app.controller("FinalSelectionController", function ($scope, $http) {

    $scope.examInfoes = {
        jobid: getParameterByName('jobid'),
        jobname: getParameterByName('jobname'),
        examTypeId: 4,
        examType: "Final Selection",
        applicantList: []
    };
    
    $http.post("http://localhost:6161/api/Exam", JSON.stringify({
        examId: $scope.examInfoes.examTypeId,
        jobId: $scope.examInfoes.jobid
    })).success(function (data) {
        $scope.examInfoes.applicantList = data;
    });
    
   
});