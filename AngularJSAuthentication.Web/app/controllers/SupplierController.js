﻿'use strict';
app.controller('SupplierController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {

    $scope.userName = localStorageService.get('authorizationData').userName;

    $scope.projectID = 0;

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
    $scope.isEditing = false; 
    $scope.ListOfSupplier = [];

    

    $scope.getSuppliersByProjectID = function (id)
    {

        $scope.projectID = id;

        ordersService.getSupplierByID(id).then(function (results) {
            $scope.ListOfSupplier = results.data;
        }, function (error) {
        });
    }




    $scope.getAll = function () {
        ordersService.getSupplier().then(function (results) {
            $scope.ListOfSupplier = results.data;
        }, function (error) {
        });
    }

    $scope.getAll();

    $scope.getdatabyid = function (id) {
        $scope.Supplier.ProjectID = id;
        ordersService.getCategoryByID(id).then(function (results) {
            $scope.categories = results.data;
        }, function (error) {
            debugger;
            //alert(error.data.message);
        });
    }

    $scope.showlistofsuppliers = function () {
        $scope.showlist = true;
        $scope.isEditing = false;
    }


    $scope.addnewsupplier = function () {
        $scope.Supplier = {
            SupplierID: "",
            Name: "",
            Address: "",
            Contact: "",
            AmountPaid: "",
            Category: "",
            TotalAmount: "",
            ProjectID: 0
        };

        $scope.showlist = false;
        $scope.isEditing = false;
    }


    $scope.openEditModal = function (obj) {
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


        $scope.isEditing = true;
        $scope.showlist = false;

    }


    $scope.customMethod = function (obj) {
        ordersService.customMethod(obj).then(function (results) {

            $scope.ListOfProjects = results.data;
        }, function (error) {
        });
    }  


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


    

    $scope.saveSupplier = function () {

        $scope.Supplier.projectID = $scope.projectID;

        ordersService.saveSupplier($scope.Supplier).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Supplier has been added successfully";

            $scope.getSuppliersByProjectID($scope.projectID);
            $scope.showlist = true;
            $scope.isEditing = false;

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

        $scope.Supplier.projectID = $scope.projectID;

        ordersService.updateSupplier($scope.Supplier).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Supplier has been updated successfully";

            $scope.getSuppliersByProjectID($scope.projectID);
            $scope.showlist = true;
            $scope.isEditing = false;
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