'use strict';
app.controller('ExpenseController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.Expense = {
        ExpenseID: null,
        ProjectID: null,
        AssetID: null,
        CategoryID:null,
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

        console.log("==============|Expense================")
        console.log(results.data)
        console.log("==============|Expense================")

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });



    $scope.addExpense = function () {

        ordersService.saveExpense($scope.Expense).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Expense has been added successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Expense due to:" + errors.join(' ');
         });
    };
}]);