var app = angular.module("ERecruitment", []);
var userName = document.getElementById("applicationUserName").value;
app.directive('datePicker', function () {
    return {
        restrict: 'AC',

        link: function(scope, iElement, iAttrs) {
            iElement.datetimepicker({
                timepicker: false,
                format: 'm/d/Y',
                formatDate: 'm/d/Y'
            });
        }
    };
});
