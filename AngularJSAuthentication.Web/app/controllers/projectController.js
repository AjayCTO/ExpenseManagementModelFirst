﻿'use strict';
app.controller('projectController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.project = {
        ProjectID:null,
        Name: "",
        BillingMethod: "",
        CustomerName: "",
        TotalCost: ""
    };
    $scope.savedSuccessfully = false;

  
    $scope.ListOfOrders = [];

    ordersService.getProjects().then(function (results) {
        $scope.ListOfOrders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });


    $scope.getProjectsByID = function (id) {

        ordersService.getProjectsByID(id).then(function (results) {

            $scope.project = results.data;

        }, function (error) {
            //alert(error.data.message);
        });
    }

    


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


    $scope.updateProject = function () {

        ordersService.updateProject($scope.project).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Project has been updated successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add update due to:" + errors.join(' ');
         });
    };


    $scope.deleteProject = function (id) {
        ordersService.deleteProject(id).then(function (results) {
            $scope.orders = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    };


    


}]);