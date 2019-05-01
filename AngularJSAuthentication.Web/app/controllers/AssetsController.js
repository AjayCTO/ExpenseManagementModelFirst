'use strict';
app.controller('AssetsController', ['$scope', 'ordersService', 'localStorageService', function ($scope, ordersService, localStorageService) {


    $scope.Asset = {
        assetID: null,
        projectID:null,
        name: "",
        contact: "",
        address: "",
        business: "",
        userID: null,
        applicationUser_Id:null
    };

    $scope.showlist = true;


    $scope.ListOfAssets = [];

    $scope.savedSuccessfully = false;

    $scope.addnewasset = function () {
        $scope.showlist = false;
    }    
  
    $scope.showlistofassets = function () {
        $scope.showlist = true;
    }

    ordersService.getAssets().then(function (results) {
        $scope.ListOfAssets = results.data;

        console.log("rrrr");
        console.log($scope.ListOfAssets);

        console.log($scope.ListOfAssets);

    }, function (error) {      
        //alert(error.data.message);
    });


    $scope.userName = localStorageService.get('authorizationData').userName;


    ordersService.getProjects($scope.userName).then(function (results) {

        $scope.ListOfProjects = results.data;
    }, function (error) {
    });


    $scope.getAssetsByID = function (id) {
        ordersService.getAssetsByID(id).then(function (results) {

            $scope.Asset = results.data;

        }, function (error) {
            //alert(error.data.message);
        });

    }    

    $scope.saveAsset = function () {

        ordersService.saveAsset($scope.Asset).then(function (response) {


            $scope.savedSuccessfully = true;
            $scope.message = "Asset has been added successfully";

            $scope.showlist = true;

        },
         function (error) {
             alert("Err");

             debugger;

             $scope.showlist = true;

             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add Asset due to:" + errors.join(' ');
         });
    };



    $scope.openEditModal = function (Asset) {

       
        $scope.Asset = {
            assetID: Asset.assetID,
            projectID: Asset.projectID,
            name: Asset.name,
            contact: Asset.contact,
            address: Asset.address,
            business: Asset.business,
            userID: Asset.userID,
            applicationUser_Id: Asset.applicationUser_Id
        };

        $scope.showlist = false;
    }



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