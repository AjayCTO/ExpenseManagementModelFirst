'use strict';
app.controller('projectController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {

    $scope.project = {
        projectID:null,
        name: "",
        billingMethod: "",
        CustomerID: null,
        TotalCost: ""
    };
    $scope.savedSuccessfully = false;

    $scope.showlist = true;

  
    $scope.ListOfProjects = [];

    $scope.userName = localStorageService.get('authorizationData').userName;


    ordersService.getProjects($scope.userName).then(function (results) {
      
        $scope.ListOfProjects = results.data;
    }, function (error) {
    });


    ordersService.getCustomer().then(function (results) {
        $scope.ListOfcustomer = results.data;

        console.log($scope.ListOfcustomer);

    }, function (error) {
    });

    $scope.newcustomer = function () {
        $("#customermodal").modal("show");
    }



    $scope.getProjectByID = function (id) {

        ordersService.getProjectByID(id).then(function (results) {

            $scope.project = results.data;

            console.log("Get By id working");
            console.log($scope.project);

        }, function (error) {
            //alert(error.data.message);
        });
    }


    $scope.addnewproject = function () {
        $scope.showlist = false;
    }

    


    $scope.saveProject = function () {


        var userName = localStorageService.get('authorizationData').userName;

       

        ordersService.saveProject($scope.project, userName).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Project has been added successfully";

            $scope.showlist = true;

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


    $scope.updateProject = function (project) {

        ordersService.updateProject(project).then(function (response) {

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