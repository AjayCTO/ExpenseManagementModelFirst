﻿'use strict';
app.controller('CategoryController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.Category = {
        CategoryID:null,
        ProjectID:null,
        name: "",
        description: ""
    };

    $scope.ListOfCategories = [];

    $scope.savedSuccessfully = false; 

    $scope.openEditModal = function(category) {
        $scope.Category = {
            categoryID: category.categoryID,
            projectID: category.projectID,
            name: category.name,
            description: category.description
        };

        $scope.showlist = false;
    }
    

    $scope.showcategorylist = function () {
        $scope.showlist = true;
    }



    $scope.showlist = true;
    ordersService.getCategory().then(function (results) {

        $scope.ListOfCategories = results.data;

    }, function (error) {
        //alert(error.data.message);
    });


    $scope.getCategoryByID = function (id) {
        ordersService.getCategoryByID(id).then(function (results) {

            $scope.Category = results.data;

        }, function (error) {
            //alert(error.data.message);
        });

    }

    $scope.addnewcategory = function () {

        $scope.Category = {
            CategoryID: null,
            ProjectID: null,
            name: "",
            description: ""
        };

        $scope.showlist = false;
    }

    
    $scope.showprojectlist = function () {
        $scope.showlist = true;
    }

    $scope.saveCategory = function () {

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


    $scope.updateCategory = function () {

        ordersService.updateCategory($scope.Category).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Category has been updated successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to update Category due to:" + errors.join(' ');
         });
    };


    $scope.deleteCategory = function (id) {
        ordersService.deleteCategory(id).then(function (results) {
            $scope.orders = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    };



}]);