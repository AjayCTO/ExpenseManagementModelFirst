'use strict';
app.controller('incomingController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {

    $scope.isEditing = false;
  
    $scope.projectID = null;

    $scope.Incoming = {
        IncomingID: null,
        ProjectID: $scope.projectID,
        Date: "",
        Amount: "",
        SourceName:""
    };


    $scope.setProjectID = function (id) {
        $scope.projectID = id;
    }

    

    $scope.savedSuccessfully = false;

    $scope.ListOfIncoming = [];

    $scope.userName = localStorageService.get('authorizationData').userName;

    ordersService.getIncoming().then(function (results) {     

        $scope.ListOfIncoming = results.data;       
    }, function (error) {
        //alert(error.data.message);
    });


    $scope.openEditModal = function (obj) {
        $scope.Incoming = {
            IncomingID: obj.incomingID,
            ProjectID: obj.projectID,
            Date: obj.date,
            Amount: obj.amount,
            SourceName: obj.sourceName
        };
        $scope.isEditing = true;
        $scope.showlist = false;
    }


    $scope.getIncomingsByProjectID = function (id) {

        $scope.Incoming.projectID = id;

        $scope.projectID = id;

        ordersService.getIncomingByProjectID(id).then(function (results) {

            $scope.ListOfIncoming = results.data;

            console.log("lit of incoming");
            console.log($scope.ListOfIncoming);


        }, function (error) {
            //alert(error.data.message);
        });
    }



    ordersService.getProjects($scope.userName).then(function (results) {      
        $scope.ListOfProjects = results.data;
    }, function (error) {
    });



    $scope.showlist = true;


    $scope.showlistofincomings = function () {
        $scope.isEditing = false;
        $scope.showlist = true;
    }



    $scope.addnewincoming = function () {
        $scope.Incoming = {
            IncomingID: null,
            ProjectID: null,
            Date: "",
            Amount: "",
            SourceName: ""
        };


        $scope.showlist = false;
        $scope.isEditing = false;
    }



    $scope.getIncomingByID = function (id) {

        ordersService.getIncomingByID(id).then(function (results) {

            $scope.Incoming = results.data;

        }, function (error) {
            //alert(error.data.message);
        });
    }

    $scope.saveIncoming = function () {

        $scope.Incoming.projectID = $scope.projectID;


        console.log("Save Incoming");
        console.log($scope.Incoming);

        ordersService.saveIncoming($scope.Incoming).then(function (response) {

            $scope.showlist = true;

            $scope.savedSuccessfully = true;
            $scope.message = "Incoming has been added successfully";

            $scope.getIncomingsByProjectID($scope.projectID);
            $scope.isEditing = false;
            $scope.showlist = true;
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
        $scope.Incoming.projectID = $scope.projectID;
        ordersService.updateIncomeing($scope.Incoming).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Incoming has been updated successfully";

            $scope.getIncomingsByProjectID($scope.projectID);
            $scope.isEditing = false;
            $scope.showlist = true;
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