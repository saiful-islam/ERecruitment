app.controller("StatusController", function ($scope, $http) {
    $scope.inputStatus = "";
    $scope.newStatus = "";
    waitCursor();
    $http.get("http://localhost:6161/api/Status").success(function (data) {
        $scope.statuses = data;
    });
    autoCursor();
    $scope.ChangeStatusInfo = function () {
        var statusId = document.getElementById('newStatusID').value;
        waitCursor();
        var objStatus = new StatusModel(statusId, $scope.newStatus);
        console.log(objStatus);
        $http.put("http://localhost:6161/api/Status", JSON.stringify(objStatus)).success(function (data) {
            console.log("Edit Status Message" + data);
            autoCursor();
            window.location.href = "/Status/Index";
        });
    };

    $scope.SaveStatusInfo = function () {
        waitCursor();
        var objStatus = new StatusModel(0, $scope.inputStatus);
        console.log(objStatus);
        $http.post("http://localhost:6161/api/Status", JSON.stringify(objStatus)).success(function (data) {
            console.log("Save Status Message:" + data);
            autoCursor();
            window.location.href = "/Status/Index";
        });

    };


    $scope.DeleteStatusInfobyID = function () {
        var statusId = document.getElementById('deleteStatusID').value;
        waitCursor();
        $http.delete("http://localhost:6161/api/Status/"+statusId).success(function (data) {
            console.log("Delete Status Message:" + data);
            autoCursor();
            window.location.href = "/Status/Index";
        });
    };

    $scope.EditStatusInfo = function (status) {
        window.location.href = "/Status/Edit?statusCode=" + status.StatusCode + "&status=" + status.Status;
    };

    $scope.DeleteStatusInfo = function (status) {
        window.location.href = "/Status/Delete?statusCode=" + status.StatusCode + "&status=" + status.Status;
    };

    $scope.GetEditStatus = function (status) {
        alert(status);
    };
});