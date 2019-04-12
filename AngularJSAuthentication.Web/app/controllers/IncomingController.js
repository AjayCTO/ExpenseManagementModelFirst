'use strict';
app.controller('IncomingController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.Incoming = {
        IncomingID: null,
        ProjectID:null,
        Date: "",
        Amount: "",
        SourceName:""
    };
    $scope.savedSuccessfully = false;

    $scope.ListOfIncoming = [];

    ordersService.getIncoming().then(function (results) {      

        $scope.ListOfIncoming = results.data;

    }, function (error) {
        //alert(error.data.message);
    });


    $scope.getIncomingByID = function (id) {

        ordersService.getIncomingByID(id).then(function (results) {

            $scope.Incoming = results.data;

        }, function (error) {
            //alert(error.data.message);
        });
    }

    $scope.addIncome = function () {

        ordersService.saveIncoming($scope.Incoming).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Incoming has been added successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Incoming due to:" + errors.join(' ');
         });
    };


    $scope.updateIncome = function () {

        ordersService.updateIncome($scope.Incoming).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Incoming has been updated successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to update Incoming due to:" + errors.join(' ');
         });
    };


    $scope.deleteIncoming = function (id) {
        ordersService.deleteIncoming(id).then(function (results) {
            $scope.orders = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    };


}]);