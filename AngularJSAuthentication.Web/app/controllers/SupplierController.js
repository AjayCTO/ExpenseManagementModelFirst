'use strict';
app.controller('SupplierController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {

    $scope.Supplier = {
        SupplierID:"",
        Name: "",
        Address: "",
        Contact: "",
        AmountPaid: "",
        Category: "",
        TotalAmount: "",
        ProjectID:0
    };
    $scope.savedSuccessfully = false;

    $scope.showlist = true;


    $scope.ListOfSupplier = [];

    ordersService.getSupplier().then(function (results) {       
        $scope.ListOfSupplier = results.data;
    }, function (error) {
    });





    $scope.getdatabyid = function (id) {

        alert(id);

        $scope.Supplier.ProjectID = id;
      
        ordersService.getCategoryByID(id).then(function (results) {

            $scope.categories = results.data;

        }, function (error) {
            debugger;
            //alert(error.data.message);
        });

        

       
    }


    $scope.getSupplierByIDdForEdit = function (obj) {
        $scope.Supplier = {
            SupplierID: obj.supplierID,
            Name: obj.name,
            Address: obj.address,
            Contact: obj.contact,
            AmountPaid: obj.amountPaid,
            Category: obj.category,
            TotalAmount: obj.totalAmount,
            ProjectID: obj.projectID
        };


        console.log("Edit");
        console.log($scope.Supplier);

        $scope.showlist = false;

    }


    $scope.userName = localStorageService.get('authorizationData').userName;


    ordersService.getProjects($scope.userName).then(function (results) {

        $scope.ListOfProjects = results.data;
    }, function (error) {
    });


    $scope.getSupplierByID = function (id) {

        ordersService.getSupplierByID(id).then(function (results) {

            $scope.project = results.data;

        }, function (error) {
            //alert(error.data.message);
        });
    }


    $scope.showlistofsuppliers = function () {
        $scope.showlist = true;
    }


    $scope.addnewsupplier = function () {
        $scope.showlist = false;
    }

    $scope.saveSupplier = function () {

        ordersService.saveSupplier($scope.Supplier).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Supplier has been added successfully";

            $scope.showlist = true;

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Supplier due to:" + errors.join(' ');
         });
    };


    $scope.updateSupplier = function () {

        ordersService.updateSupplier($scope.Supplier).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Supplier has been updated successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Supplier due to:" + errors.join(' ');
         });
    };


    $scope.deleteSupplier = function (id) {
        ordersService.deleteSupplier(id).then(function (results) {
            $scope.Supplier = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    };

}]);