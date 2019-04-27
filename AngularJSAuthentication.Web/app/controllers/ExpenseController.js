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

    $scope.Categoryobject = {
        CategoryID: null,
        ProjectID: 1,
        Name: "",
        Description: ""
    };

    $scope.Assetobject = {
        AssetID: null,
        ProjectID: 1,
        Name: "",
        Contact: "",
        Address: "",
        Business: "",
        UserID: null,
        ApplicationUser_Id: null
    };

    $scope.newcategoryname = "";

    $scope.savedSuccessfully = false;

    $scope.ListOfExpenses = [];

    ordersService.getExpense().then(function (results) {
      
        $scope.ListOfExpenses = results.data;

    }, function (error) {
      
        //alert(error.data.message);
    });






    $scope.saveNewCategory = function () {

        var userName = localStorageService.get('authorizationData').userName;
       
        ordersService.saveCategory($scope.Categoryobject).then(function (response) {

            $("#categorymodal").modal("hide");

            debugger;

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



    $scope.saveNewAsset = function () {


        ordersService.saveAsset($scope.Assetobject).then(function (response) {

            $("#assetmodal").modal("hide");

            debugger;

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




  


    ordersService.getProjects().then(function (results) {
        $scope.projects = results.data;

    }, function (error) {
    });


    ordersService.getAssets().then(function (results) {

        $scope.assets = results.data;

    }, function (error) {

        //alert(error.data.message);
    });


    ordersService.getCategory().then(function (results) {
        console.log("ddd")
        console.log(results)

        $scope.categories = results.data;

        alert("All cat");
        debugger;


    }, function (error) {

  

     
       
        //alert(error.data.message);
    });

    $scope.newcategory = function () {
     

        $("#categorymodal").modal("show");
    }

    $scope.newasset = function () {
     

        $("#assetmodal").modal("show");
    }


    


   


    $scope.getExpenseByID = function (id) {
        ordersService.getExpenseByID(id).then(function (results) {
            $scope.Expense = results.data;

        }, function (error) {
            //alert(error.data.message);
        });

    }



    $scope.saveExpense = function () {

        var userName = localStorageService.get('authorizationData').userName;

        ordersService.saveExpense($scope.Expense, userName).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "Expense has been added successfully";

        },
         function (error) {

             alert("eerrrr");
             debugger;
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Expense due to:" + errors.join(' ');
         });
    };


    $scope.updateExpense = function () {

        ordersService.updateExpense($scope.Expense).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Expense has been updated successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to update Expense due to:" + errors.join(' ');
         });
    };


    $scope.deleteExpense = function (id) {
        ordersService.deleteExpense(id).then(function (results) {
            $scope.orders = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    };



}]);