﻿app.controller("JobController", function ($scope, $http) {
    $scope.showJobList = true;
    $scope.showCreateJob = false;
    $scope.checkedJobBasicInfo = false;
    $scope.checkedSkill = false;
    $scope.showEditbtn = false;
    $scope.editJobId = 0;
    $scope.inputJobTitle = "";
    $scope.inputMinimumExperiance = "";
    $scope.inputMaximumExperiance = "";
    $scope.inputSubmissionDeadline = "";
    $scope.SectionId = 0;

    $scope.skills = [];
    $scope.skills.push(new RequiredJobSkillModel(0, 0));


    $http.get("http://localhost:6161/api/Job").success(function (data) {
        $scope.jobs = data;
    });
    $http.get("http://localhost:6161/api/Skill").success(function (data) {
        $scope.skillNames = data;
    });
    $http.get("http://localhost:6161/api/Section").success(function (data) {
        $scope.sections = data;
    });
    $scope.AddSkill = function () {
        $scope.skills.push(new RequiredJobSkillModel(0, 0));
    };
    $scope.RemoveSkill = function () {
        $scope.skills.splice($scope.skills.length - 1);
    };

    $scope.SaveJobInfo = function () {
        waitCursor();
        var objJob = new JobModel(0, $scope.inputJobTitle, userName, $scope.inputMinimumExperiance
                                  , $scope.inputMaximumExperiance, $scope.inputSubmissionDeadline, $scope.SectionId);
        console.log(objJob);
        $http.post("http://localhost:6161/api/Job", JSON.stringify({
            objJob: objJob,
            objSkill: $scope.skills
        })).success(function (data) {
            console.log("Save Job Message:" + data);
            autoCursor();
            window.location.href = "/Job/Index";
        });
    };

    $scope.CreateJob = function () {
        $scope.showJobList = false;
        $scope.showCreateJob = true;
        $scope.showEditbtn = false;
        $scope.inputJobTitle = "";
        $scope.inputMinimumExperiance = "";
        $scope.inputMaximumExperiance = "";
        $scope.inputSubmissionDeadline = "";
        $scope.SectionId = 0;

        $scope.skills = [];
        $scope.skills.push(new RequiredJobSkillModel(0, 0));

    };
    $scope.BackJobList = function () {
        $scope.showJobList = true;
        $scope.showCreateJob = false;
    };
    $scope.EditJobInfo = function (jobId) {
        $scope.showEditbtn = true;
        $scope.showJobList = false;
        $scope.showCreateJob = true;
        $scope.editJobId = jobId;
        $http.get("http://localhost:6161/api/Job/"+jobId).success(function (data) {
            $scope.inputJobTitle = data[0].JobName;
            $scope.inputMinimumExperiance = data[0].MinimumExperiance;
            $scope.inputMaximumExperiance = data[0].MaximumExperiance;
            $scope.inputSubmissionDeadline = formatDate(new Date(data[0].SubmissionDeadline));
            $scope.SectionId = data[0].SectionId;

            $http.get("http://localhost:6161/api/JobSkillHistory/" + jobId).success(function (data) {
                $scope.skills = data;
            });

        });
        
    };
    $scope.DeleteJobInfo = function (jobId) {
        console.log(jobId);
    };
    
    $scope.UpdateJobInfo = function () {
        waitCursor();
        var objJob = new JobModel($scope.editJobId, $scope.inputJobTitle, userName, $scope.inputMinimumExperiance
                                  , $scope.inputMaximumExperiance, $scope.inputSubmissionDeadline, $scope.SectionId);
        console.log(objJob);
        $http.put("http://localhost:6161/api/Job", JSON.stringify({
            objJob: objJob,
            objSkill: $scope.skills
        })).success(function (data) {
            console.log("Update Job Message:" + data);
            autoCursor();
            window.location.href = "/Job/Index";
        });
    };

});