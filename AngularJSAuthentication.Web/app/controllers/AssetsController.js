'use strict';
app.controller('AssetsController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.Asset = {
        AssetID: null,
        ProjectID:null,
        Name: "",
        Contact: "",
        Address: "",
        Business: "",
        UserID: null,
        ApplicationUser_Id:null
    };
    $scope.savedSuccessfully = false;

    $scope.orders = [];

    ordersService.getAssets().then(function (results) {

        console.log("==============|Asset================")
        console.log(results.data)
        console.log("==============|Asset================")

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });



    $scope.addAsset = function () {

        ordersService.saveAsset($scope.Asset).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Asset has been added successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Asset due to:" + errors.join(' ');
         });
    };





}]);