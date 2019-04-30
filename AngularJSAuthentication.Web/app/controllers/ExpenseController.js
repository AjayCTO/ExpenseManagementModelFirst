'use strict';
app.controller('ExpenseController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {
        
    $scope.Expense = {
        ExpenseID: null,
        ProjectID: null,
        AssetID: null,
        CategoryID: null,
        SupplierID:null,
        Date: "",
        Amount: "",
        Refrense: "",
        ReceiptPath: "",
        IsApproved: "",
        Description: "" 
    };

    $scope.Categoryobject = {
        CategoryID: null,
        ProjectID: 0,
        Name: "",
        Description: ""
    };

    $scope.Assetobject = {
        AssetID: null,
        ProjectID: 0;,
        Name: "",
        Contact: "",
        Address: "",
        Business: "",
        UserID: null,
        ApplicationUser_Id: null
    };

    $scope.Supplierobject = {
      
        Name: "",
        Address: "",
        Contact: "",
        ProjectID:0;
      
    };


    $scope.addnewexpense = function () {
        $scope.showlist = false;
    }

    $scope.showlist = true;

    $scope.newcategoryname = "";

    $scope.savedSuccessfully = false;

    $scope.ListOfExpenses = [];

    ordersService.getExpense().then(function (results) {

        $scope.ListOfExpenses = results.data;
        console.log($scope.ListOfExpenses);

    }, function (error) {
      
        //alert(error.data.message);
    });


    $scope.getdatabyid = function (id) {

        $scope.Expense.ProjectID = id;
        $scope.Categoryobject.ProjectID = id;
        $scope.Assetobject.ProjectID = id;
        $scope.Supplierobject.ProjectID = id;
            ordersService.getCategoryByID(id).then(function (results) {

                $scope.categories = results.data;

            }, function (error) {
                debugger;
                //alert(error.data.message);
            });

            ordersService.getSupplierByID(id).then(function (results) {

                $scope.suppliers = results.data;

            }, function (error) {
                //alert(error.data.message);
            });

            ordersService.getAssetsByID(id).then(function (results) {

                $scope.assets = results.data;

            }, function (error) {
                //alert(error.data.message);
            });
      


   
    }


    $.ajax({
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        url: "http://localhost:26264/api/Expenses/GetData",
      
        success: function (data) {
          
        },
        error: function (error) {

          
        }
    });


    



    $scope.saveNewCategory = function () {

    
       
        ordersService.saveCategory($scope.Categoryobject).then(function (response) {

            $("#categorymodal").modal("hide");

            debugger;

            $scope.getcategoryagain()

            setTimeout(function () {

                debugger;

                $scope.Expense.CategoryID = response.data.categoryID;
                $scope.$apply();

            }, 1500)

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

            $scope.getassetsagain();

            setTimeout(function () {

                debugger;

                $scope.Expense.AssetID = response.data.assetID;
                $scope.$apply();

            },1500)

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


    $scope.saveNewSupplier = function () {



        ordersService.saveSupplier($scope.Supplierobject).then(function (response) {

            $("#suppliermodal").modal("hide");

            debugger;

            $scope.getsupplieragain();

            setTimeout(function () {

                debugger;

                $scope.Expense.SupplierID = response.data.supplierID;
                $scope.$apply();

            }, 1500)

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


    $scope.getassetsagain = function () {
        ordersService.getAssets().then(function (results) {

            $scope.assets = results.data;


        }, function (error) {

            //alert(error.data.message);
        });
    }



    ordersService.getAssets().then(function (results) {

        $scope.assets = results.data;

    }, function (error) {

        //alert(error.data.message);
    });


    $scope.getcategoryagain = function () {
        ordersService.getCategory().then(function (results) {
            $scope.categories = results.data;

        }, function (error) {
        });
    }


    ordersService.getCategory().then(function (results) {     
        $scope.categories = results.data;      

    }, function (error) {
    });


    $scope.getsupplieragain = function () {
        ordersService.getSupplier().then(function (results) {

            debugger;
            $scope.suppliers = results.data;

        }, function (error) {
        });
    }


    ordersService.getSupplier().then(function (results) {

        debugger;
        $scope.suppliers = results.data;

    }, function (error) {
    });


    $scope.newcategory = function () {
     

        $("#categorymodal").modal("show");
    }

    $scope.newasset = function () {
     

        $("#assetmodal").modal("show");
    }


    $scope.newsupplier = function () {


        $("#suppliermodal").modal("show");
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