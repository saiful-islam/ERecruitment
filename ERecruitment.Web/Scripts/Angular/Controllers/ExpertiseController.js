app.controller("ExpertiseController", function ($scope, $http) {
    $scope.inputExpertiseName = "";
    $http.get("http://localhost:6161/api/Expertise").success(function (data) {
        
        $scope.expertises = data;
    });
    $scope.SaveExpertiseInfo = function () {
        waitCursor();
        var objExpertise = new Expertisemodel(0, $scope.inputExpertiseName);
        console.log(objExpertise);
        $.ajax({
            url: "http://localhost:6161/api/Expertise",
            contentType: "application/json; charset=utf-8",
            type: "POST",
            dataType: "json",
            data: JSON.stringify(objExpertise),
            success: function (data) {
                autoCursor();
                window.location.href = "/Expertise/Index";
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log("Error in Operation" + xhr.responseText);
                autoCursor();
            }
        });

    };
});