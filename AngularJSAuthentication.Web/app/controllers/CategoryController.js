'use strict';
app.controller('CategoryController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.Category = {
        CategoryID:null,
        ProjectID:null,
        Name: "",
        Description: ""
    };
    $scope.savedSuccessfully = false;

    $scope.orders = [];

    ordersService.getCategory().then(function (results) {

        console.log("==============|Category================")
        console.log(results.data)
        console.log("==============|Category================")

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });



    $scope.addCategory = function () {

        ordersService.saveCategory($scope.Category).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Category has been added successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Category due to:" + errors.join(' ');
         });
    };
}]);