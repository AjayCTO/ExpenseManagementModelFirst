'use strict';
app.controller('ExpenseController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.Expense = {
        Date: "",
        Amount: "",
        Refrense: "",
        ReceiptPath: "",
        IsApproved: "",
        Description: "" 
    };
    $scope.savedSuccessfully = false;

    $scope.orders = [];

    ordersService.getExpense().then(function (results) {

        console.log("==============|Projects================")
        console.log(results.data)
        console.log("==============|Projects================")

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });



    $scope.addExpense = function () {

        ordersService.saveExpense($scope.Expense).then(function (response) {

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