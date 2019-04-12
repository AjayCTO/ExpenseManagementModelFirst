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

    $scope.orders = [];

    ordersService.getIncoming().then(function (results) {

        console.log("==============|Incoming================")
        console.log(results.data)
        console.log("==============|Incoming================")

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });



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
}]);