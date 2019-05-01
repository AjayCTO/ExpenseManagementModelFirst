'use strict';
app.controller('homeController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {

  

    $scope.projectid = 0;

    $scope.Projectname = "My Project";
    $scope.totalcost = 1255;
    $scope.totalexpense = 1000;
    $scope.totalincoming = 300;


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
           
            console.log("List of expenses")
            console.log($scope.ListOfExpenses)

        }, function (error) {

            //alert(error.data.message);
        });
    }


    $scope.userName = localStorageService.get('authorizationData').userName;


    ordersService.getProjects($scope.userName).then(function (results) {

        $scope.ListOfProjects = results.data;
    }, function (error) {
    });



    ordersService.getExpense($scope.userName).then(function (results) {

        $scope.ListOfExpenses = results.data;
        console.log($scope.ListOfExpenses);

    }, function (error) {

        //alert(error.data.message);
    });


   
}]);