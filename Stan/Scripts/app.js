var StudentApp = angular.module('stanApp', []);
StudentApp.controller('StudentController', function ($scope, StudentService) {
 
    getStudents();
    function getStudents() {
        StudentService.getStudents()
            .success(function (studs) {
                $scope.students = studs;
                console.log($scope.students);
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }
});
 
StudentApp.factory('StudentService', ['$http', function ($http) {
 
    var StudentService = {};
    StudentService.getStudents = function () {
        return $http.get('/Stan/GetPersons');
    };
    return StudentService;
 
}]);