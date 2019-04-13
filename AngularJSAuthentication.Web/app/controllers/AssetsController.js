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




    $scope.ListOfAssets = [];

    $scope.savedSuccessfully = false;

  

    ordersService.getAssets().then(function (results) {

        $scope.ListOfAssets = results.data;


    }, function (error) {

      
        //alert(error.data.message);
    });


    ordersService.getProjects().then(function (results) {
        $scope.projects = results.data;
     
    }, function (error) {
    });



    $scope.getAssetsByID = function (id) {
        ordersService.getAssetsByID(id).then(function (results) {

            $scope.Asset = results.data;

        }, function (error) {
            //alert(error.data.message);
        });

    }




    

    $scope.addAsset = function () {

        ordersService.saveAsset($scope.Asset).then(function (response) {

            alert("Successs");

            $scope.savedSuccessfully = true;
            $scope.message = "Asset has been added successfully";

        },
         function (error) {
             alert("Err");

             debugger;

             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Asset due to:" + errors.join(' ');
         });
    };

    $scope.updateAsset = function () {

        ordersService.updateAsset($scope.Asset).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Asset has been updated successfully";

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to update Asset due to:" + errors.join(' ');
         });
    };

    $scope.deleteAsset = function (id) {
        ordersService.deleteAsset(id).then(function (results) {
            $scope.orders = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    };


}]);