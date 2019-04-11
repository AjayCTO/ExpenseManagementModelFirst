'use strict';
app.controller('CategoryController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.Category = {
        Name: "",
        Description: ""
    };
    $scope.savedSuccessfully = false;

    $scope.orders = [];

    ordersService.getCategory().then(function (results) {

        console.log("==============|Projects================")
        console.log(results.data)
        console.log("==============|Projects================")

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });



    $scope.addCategory = function () {

        ordersService.saveCategory($scope.Category).then(function (response) {

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