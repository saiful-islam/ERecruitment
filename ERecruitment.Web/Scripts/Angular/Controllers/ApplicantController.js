app.controller("ApplicantController", function($scope, $http) {
    $scope.checked = false;
    $scope.checkedCareer = false;
    $scope.checkedProject = false;
    $scope.checkedEducation = false;
    $scope.checkedSkill = false;
    $scope.selectedStatus = "";
    $scope.selectedExpertise = "";
    $scope.inputFirstName = "";
    $scope.inputLastName = "";
    $scope.inputMobileNo = "";
    $scope.inputEmail = "";
    $scope.inputMailingAddress = "";
    $scope.selectedStatus = "";
    $scope.selectExpertise = "";
    $scope.editedApplicantId = 0;

    $scope.showApplicantList = true;
    $scope.showCreateApplicant = false;
    $scope.showEditbtn = false;
    $scope.showDetails = false;

    $scope.CreateApplicant = function() {
        $scope.showApplicantList = false;
        $scope.showCreateApplicant = true;

        $scope.checked = false;
        $scope.checkedCareer = false;
        $scope.checkedProject = false;
        $scope.checkedEducation = false;
        $scope.checkedSkill = false;
        $scope.selectedStatus = "";
        $scope.selectedExpertise = "";
        $scope.inputFirstName = "";
        $scope.inputLastName = "";
        $scope.inputMobileNo = "";
        $scope.inputEmail = "";
        $scope.inputMailingAddress = "";
        $scope.selectedStatus = "";
        $scope.selectExpertise = "";

        $scope.careers = [];
        $scope.careers.push(new CareerModel(0, 0, "", "", "", "", "", ""));

        $scope.projects = [];
        $scope.projects.push(new ProjectThesisModel(0, 0, "", "", "", "", "", false));

        $scope.educations = [];
        $scope.educations.push(new EducationModel(0, 0, 0, "", "", "", false));

        $scope.skills = [];
        $scope.skills.push(new SkillHistoryModel(0, 0, false));

        $scope.showEditbtn = false;
    };

    $scope.BackApplicantList = function () {
        $scope.showApplicantList = true;
        $scope.showCreateApplicant = false;
        $scope.showDetails = false;
        $scope.checked = false;
        $scope.checkedCareer = false;
        $scope.checkedProject = false;
        $scope.checkedEducation = false;
        $scope.checkedSkill = false;
    };

    $http.get("http://localhost:6161/api/Status").success(function (data) {
        $scope.statuses = data;
    });
    $http.get("http://localhost:6161/api/Expertise").success(function (data) {
        $scope.expertises = data;
    });
    $http.get("http://localhost:6161/api/Education").success(function (data) {
        $scope.educationNames = data;
    });
    $http.get("http://localhost:6161/api/Institute").success(function (data) {
        $scope.institutes = data;
    });
    $http.get("http://localhost:6161/api/Skill").success(function (data) {
        $scope.skillNames = data;
    });

    $scope.careers = [];
    $scope.careers.push(new CareerModel(0, 0, "", "", "", "", "", ""));

    $scope.projects = [];
    $scope.projects.push(new ProjectThesisModel(0, 0, "", "", "", "", "", false));

    $scope.educations = [];
    $scope.educations.push(new EducationModel(0, 0, 0, "", "", "", false));

    $scope.skills = [];
    $scope.skills.push(new SkillHistoryModel(0, 0, false));

    $scope.SaveApplicantInfo = function () {
        waitCursor();
        var objApplicant = new ApplicantModel(0, $scope.inputFirstName, $scope.inputLastName, $scope.inputMobileNo
                                            , $scope.inputEmail, $scope.inputMailingAddress, $scope.selectedStatus
                                            ,$scope.selectedExpertise);
        console.log(objApplicant);
        $http.post("http://localhost:6161/api/Applicant", JSON.stringify({
            objApplicantInfo: objApplicant,
            objCareerInfo: $scope.careers,
            objProjectThesisInfo: $scope.projects,
            objEducation: $scope.educations,
            objSkill: $scope.skills
        })).success(function (data) {
            console.log("Save Applicant Message:" + data);
            autoCursor();
            window.location.href = "/Applicant/Index";
        });

    };
    $scope.AddCarrerInfo = function () {
        $scope.careers.push(new CareerModel(0, 0, "", "", "", "", "", ""));
    };
    $scope.RemoveCarrerInfo = function () {
        $scope.careers.splice($scope.careers.length - 1);
    };
    $scope.AddProjectInfo = function () {
        $scope.projects.push(new ProjectThesisModel(0, 0, "", "", "", "", "", false));
    };
    $scope.RemoveProjectInfo = function () {
        $scope.projects.splice($scope.projects.length - 1);
    };
    $scope.AddEducationInfo = function () {
        $scope.educations.push(new EducationModel(0, 0, 0, "", "", "", false));
    };
    $scope.RemoveEducationInfo = function () {
        $scope.educations.splice($scope.educations.length - 1);
    };
    $scope.AddSkill = function () {
        $scope.skills.push(new SkillHistoryModel(0, 0, false));
    };
    $scope.RemoveSkill = function () {
        $scope.skills.splice($scope.skills.length - 1);
    };
    $scope.EditApplicantInfo = function (applicantId) {
        $http.get("http://localhost:6161/api/Applicant/" + applicantId+"").success(function (data) {
            console.log(data);
            $scope.editedApplicantId = applicantId;
            $scope.inputFirstName = data[0].FirstName;
            $scope.inputLastName = data[0].LastName;
            $scope.inputMobileNo = data[0].MobileNo;
            $scope.inputEmail = data[0].Email;
            $scope.inputMailingAddress = data[0].MailingAddress;
            $scope.selectedStatus = data[0].StatusCode;
            $scope.selectedExpertise = data[0].ExpertiseCode;
            $http.get("http://localhost:6161/api/CareerInfo/" + applicantId + "").success(function (data) {
                $scope.careers = data;
            });
            $http.get("http://localhost:6161/api/ProjectThesisInfo/" + applicantId + "").success(function (data) {
                $scope.projects = data;
            });
            $http.get("http://localhost:6161/api/EducationHistory/" + applicantId + "").success(function (data) {
                $scope.educations = data;
            });
            $http.get("http://localhost:6161/api/SkillHistory/" + applicantId + "").success(function (data) {
                $scope.skills = data;
            });
            $scope.showApplicantList = false;
            $scope.showCreateApplicant = true;
            $scope.showEditbtn = true;
            //$scope.showDetails = false;

        });
        
    };
    $scope.DeleteApplicantInfo = function (applicantId) {
        console.log(applicantId);
    };
    $scope.DetailsApplicantInfo = function (applicantId) {
        $scope.showDetails = true;
        $scope.checked = true;
        $scope.checkedCareer = true;
        $scope.checkedProject = true;
        $scope.checkedEducation = true;
        $scope.checkedSkill = true;
        $scope.EditApplicantInfo(applicantId);
    };
    $scope.UpdateApplicantInfo = function () {
        waitCursor();
        var objApplicant = new ApplicantModel($scope.editedApplicantId, $scope.inputFirstName, $scope.inputLastName, $scope.inputMobileNo
                                            , $scope.inputEmail, $scope.inputMailingAddress, $scope.selectedStatus
                                            , $scope.selectedExpertise);
        console.log(objApplicant);
        $http.put("http://localhost:6161/api/Applicant", JSON.stringify({
            objApplicantInfo: objApplicant,
            objCareerInfo: $scope.careers,
            objProjectThesisInfo: $scope.projects,
            objEducation: $scope.educations,
            objSkill: $scope.skills
        })).success(function (data) {
            console.log("Update Applicant Message:" + data);
            autoCursor();
            window.location.href = "/Applicant/Index";
        });
    };
    //// Ag Grid

    var columnDefs = [
        // this row just shows the row index, doesn't use any data from the row
        //{
        //    headerName: "#", width: 50, cellRenderer: function (params) {
        //        return params.node.id + 1;
        //    }
        //},
        { headerName: "First Name", field: "FirstName" },
        { headerName: "Last Name", field: "LastName"},
        { headerName: "Mobile", field: "MobileNo"},
        { headerName: "E-Mail", field: "Email" },
        { headerName: "Mailing Address", field: "MailingAddress" },
        { headerName: "Status", field: "Status" },
        { headerName: "Expertise", field: "ExpertiseName"},
        { headerName: "", field: "ApplicantID", width: 250, cellRenderer: valueCellRenderer, cellFilter: false }
    ];
    function valueCellRenderer(params) {
        return cellRendererNormalCell(params);
    }
    $scope.pageSize = '500';
    var TEMPLATE = '<button class="btn btn-primary btn-xs" id="btnEdit">Edit</button>  <button class="btn btn-danger btn-xs" id="btnDelete">Delete</button>  <button class="btn btn-info btn-xs" id="btnDetails">Details</button>';

    function cellRendererNormalCell(params) {
        var eSpan = document.createElement('div');

        eSpan.innerHTML = TEMPLATE;

        eSpan.querySelector('#btnEdit').addEventListener('click', function () {
            $scope.EditApplicantInfo(params.value);
        });
        eSpan.querySelector('#btnDelete').addEventListener('click', function () {
            $scope.DeleteApplicantInfo(params.value);
        });
        eSpan.querySelector('#btnDetails').addEventListener('click', function () {
            $scope.DetailsApplicantInfo(params.value);
        });
        return eSpan;
    }

    $scope.gridOptions = {
        // note - we do not set 'virtualPaging' here, so the grid knows we are doing standard paging
        enableSorting: true,
        enableFilter: true,
        enableColResize: true,
        columnDefs: columnDefs
    };

    $scope.onPageSizeChanged = function () {
        createNewDatasource();
    };

    // when json gets loaded, it's put here, and  the datasource reads in from here.
    // in a real application, the page will be got from the server.
    var allOfTheData=[];

    $http.get("http://localhost:6161/api/Applicant").success(function (data) {
        angular.forEach(data, function (value, key) {
            allOfTheData.push(value);
        });
        console.log(allOfTheData);
        createNewDatasource();
        
    });
    function createNewDatasource() {
        if (!allOfTheData) {
            // in case user selected 'onPageSizeChanged()' before the json was loaded
            return;
        }

        var dataSource = {
            //rowCount: ???, - not setting the row count, infinite paging will be used
            pageSize: parseInt($scope.pageSize), // changing to number, as scope keeps it as a string
            getRows: function (params) {
                // this code should contact the server for rows. however for the purposes of the demo,
                // the data is generated locally, a timer is used to give the experience of
                // an asynchronous call
                //setTimeout(function () {
                    // take a chunk of the array, matching the start and finish times
                    var rowsThisPage = allOfTheData.slice(params.startRow, params.endRow);
                    // see if we have come to the last page. if we have, set lastRow to
                    // the very last row of the last page. if you are getting data from
                    // a server, lastRow could be returned separately if the lastRow
                    // is not in the current page.
                    var lastRow = -1;
                    if (allOfTheData.length <= params.endRow) {
                        lastRow = allOfTheData.length;
                    }
                    params.successCallback(rowsThisPage, lastRow);
                //}, 500);
            }
        };

        $scope.gridOptions.api.setDatasource(dataSource);
        $scope.gridOptions.api.sizeColumnsToFit();
    }
   
    $scope.onBtExport = function () {
        var params = {
            skipHeader: false,
            skipFooters: true,
            skipGroups: true,
            fileName: "Applicant_List.csv"
        };

        $scope.gridOptions.api.exportDataAsCsv(params);
    };
    ////End AG

});