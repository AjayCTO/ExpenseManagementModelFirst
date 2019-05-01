'use strict';
app.controller('incomingController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {

   

    $scope.Incoming = {
        IncomingID: null,
        ProjectID:null,
        Date: "",
        Amount: "",
        SourceName:""
    };
    $scope.savedSuccessfully = false;

    $scope.ListOfIncoming = [];

    $scope.userName = localStorageService.get('authorizationData').userName;

    ordersService.getIncoming().then(function (results) {

       

        $scope.ListOfIncoming = results.data;
        console.log("Incoming");
        console.log($scope.ListOfIncoming);

    }, function (error) {
        //alert(error.data.message);
    });


    ordersService.getProjects($scope.userName).then(function (results) {

        alert("Success");
        debugger;

        $scope.ListOfProjects = results.data;
    }, function (error) {
    });



    $scope.showlist = true;

    $scope.addnewincoming = function () {
        $scope.showlist = false;
    }



    $scope.getIncomingByID = function (id) {

        ordersService.getIncomingByID(id).then(function (results) {

            $scope.Incoming = results.data;

        }, function (error) {
            //alert(error.data.message);
        });
    }

    $scope.saveIncoming = function () {

        debugger;


        ordersService.saveIncoming($scope.Incoming).then(function (response) {

            $scope.showlist = true;

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


    $scope.updateIncomeing = function () {

        ordersService.updateIncomeing($scope.Incoming).then(function (response) {

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