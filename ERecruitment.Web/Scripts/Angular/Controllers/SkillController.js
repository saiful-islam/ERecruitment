app.controller("SkillController", function ($scope, $http) {
    $scope.inputSkillName = "";
    $scope.newSkillName = "";
    waitCursor();
    $http.get("http://localhost:6161/api/Skill").success(function (data) {
        $scope.Skills = data;
    });
    autoCursor();
    $scope.ChangeSkillInfo = function () {
        var SkillId = document.getElementById('newSkillID').value;
        waitCursor();
        var objSkill = new SkillModel(SkillId, $scope.newSkillName);
        console.log(objSkill);
        $http.put("http://localhost:6161/api/Skill", JSON.stringify(objSkill)).success(function (data) {
            console.log("Edit Skill Message" + data);
            autoCursor();
            window.location.href = "/Skill/Index";
        });
    };

    $scope.SaveSkillInfo = function () {
        waitCursor();
        var objSkill = new SkillModel(0, $scope.inputSkillName);
        console.log(objSkill);
        $http.post("http://localhost:6161/api/Skill", JSON.stringify(objSkill)).success(function (data) {
            console.log("Save Skill Message:" + data);
            autoCursor();
            window.location.href = "/Skill/Index";
        });

    };


    $scope.DeleteSkillInfobyID = function () {
        var SkillId = document.getElementById('deleteSkillID').value;
        waitCursor();
        $http.delete("http://localhost:6161/api/Skill/"+SkillId).success(function (data) {
            console.log("Delete Skill Message:" + data);
            autoCursor();
            window.location.href = "/Skill/Index";
        });
    };

    $scope.EditSkillInfo = function (Skill) {
        window.location.href = "/Skill/Edit?SkillID=" + Skill.SkillID + "&SkillName=" + Skill.SkillName;
    };

    $scope.DeleteSkillInfo = function (Skill) {
        window.location.href = "/Skill/Delete?SkillID=" + Skill.SkillID + "&SkillName=" + Skill.SkillName;
    };

    $scope.GetEditSkill = function (Skill) {
        alert(Skill);
    };
});