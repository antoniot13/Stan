var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) {    
    $http.get("http://localhost:57087/Api/Get?howMany=4")
    .then(function (response) {
        $scope.suggestions = response.data;        
    });    
});