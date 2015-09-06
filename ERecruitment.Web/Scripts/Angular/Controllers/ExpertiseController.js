app.controller("ExpertiseController", function ($scope, $http) {
    $scope.inputExpertiseName = "";
    $scope.newExpertiseName = "";
    waitCursor();
    $http.get("http://localhost:6161/api/Expertise").success(function (data) {
        $scope.expertises = data;
    });
    autoCursor();
    $scope.ChangeExpertiseInfo = function () {
        var expertiseID=document.getElementById('newExpertiseID').value;
        waitCursor();
        var objExpertise = new Expertisemodel(expertiseID, $scope.newExpertiseName);
        console.log(objExpertise);
        $http.put("http://localhost:6161/api/Expertise", JSON.stringify(objExpertise)).success(function (data) {
            console.log("Edit Expertise Message" + data);
            autoCursor();
            window.location.href = "/Expertise/Index";
        });
    };

    $scope.SaveExpertiseInfo = function () {
        waitCursor();
        var objExpertise = new Expertisemodel(0, $scope.inputExpertiseName);
        console.log(objExpertise);
        $http.post("http://localhost:6161/api/Expertise", JSON.stringify(objExpertise)).success(function (data) {
            console.log("Save Expertise Message:" + data);
            autoCursor();
            window.location.href = "/Expertise/Index";
        });

    };


    $scope.DeleteExpertiseInfobyID = function () {
        var expertiseID = document.getElementById('deleteExpertiseID').value;
        waitCursor();
        $http.delete("http://localhost:6161/api/Expertise/"+expertiseID).success(function (data) {
            console.log("Delete Expertise Message:" + data);
            autoCursor();
            window.location.href = "/Expertise/Index";
        });
    };

    $scope.EditExpertiseInfo = function (expertise) {
        window.location.href = "/Expertise/Edit?expertiseCode=" + expertise.ExpertiseCode+"&expertiseName=" + expertise.ExpertiseName;
    };

    $scope.DeleteExpertiseInfo = function (expertise) {
        window.location.href = "/Expertise/Delete?expertiseCode=" + expertise.ExpertiseCode + "&expertiseName=" + expertise.ExpertiseName;
    };

    $scope.GetEditExpertise = function (expertise) {
        alert(expertise);
    };
});