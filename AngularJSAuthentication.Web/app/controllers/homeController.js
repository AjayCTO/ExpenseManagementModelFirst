'use strict';
app.controller('homeController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {

    $scope.projectID = localStorageService.get('projectID').projectID;
    $scope.userName = localStorageService.get('authorizationData').userName;
    

    //$scope.Projectname = "My Project";
    //$scope.totalcost = 1255;
    //$scope.totalexpense = 1000;
    //$scope.totalincoming = 300;


    $scope.getTransactionByID = function (id) {

        ordersService.getTransactionByID(id).then(function (results) {   

            $scope.Projectname = results.data.projectName;
            $scope.totalcost = results.data.totalCost
            $scope.totalexpense = results.data.totalExpense
            $scope.totalincoming = results.data.totalIncoming

        }, function (error) {
            //alert(error.data.message);
        });


        ordersService.getExpenseByProjectID(id).then(function (results) {

            $scope.ListOfExpenses = results.data;         
        

        }, function (error) {

            //alert(error.data.message);
        });


        ordersService.getIncomingByProjectID(id).then(function (results) {

            $scope.ListOfIncomings = results.data;


        }, function (error) {

            //alert(error.data.message);
        });


        ordersService.getAssetsByProjectID(id).then(function (results) {

            $scope.ListOfAssets = results.data;

            console.log("list of ass");
            console.log($scope.ListOfAssets);
        }, function (error) {

            //alert(error.data.message);
        });
        

    }
    


    ordersService.getProjects($scope.userName).then(function (results) {

        $scope.ListOfProjects = results.data;

        localStorageService.set('projectID', { projectID: $scope.ListOfProjects[0].projectID });

        $scope.getTransactionByID($scope.ListOfProjects[0].projectID);

    }, function (error) {
    });



    //ordersService.getExpense($scope.userName).then(function (results) {

    //    $scope.ListOfExpenses = results.data;
    //    console.log($scope.ListOfExpenses);

    //}, function (error) {

    //    //alert(error.data.message);
    //});

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }
   
}]);