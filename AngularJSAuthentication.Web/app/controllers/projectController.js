'use strict';
app.controller('projectController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.project = {
        Name: "",
        BillingMethod: "",
        CustomerName: "",
        TotalCost: ""
    };
    $scope.savedSuccessfully = false;

    $scope.orders = [];

    ordersService.getProjects().then(function (results) {

        console.log("==============|Projects================")
        console.log(results.data)
        console.log("==============|Projects================")

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });



    $scope.addProject = function () {

        ordersService.saveProject($scope.project).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Project has been added successfully";           

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add project due to:" + errors.join(' ');
         });
    };





}]);