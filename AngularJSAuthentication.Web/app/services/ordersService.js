'use strict';
app.factory('ordersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var ordersServiceFactory = {};

    var _getOrders = function () {

        return $http.get(serviceBase + 'api/orders').then(function (results) {
            return results;
        });
    };


    var _getProjects = function () {

        return $http.get(serviceBase + 'api/Project').then(function (results) {
            return results;
        });
    };


    var _saveProject = function (project) {
      

        return $http.post(serviceBase + 'api/Project/PostProject', project).then(function (response) {
            return response;
        });

    };

    var _getAssets = function () {

        return $http.get(serviceBase + 'api/Asset').then(function (results) {
            return results;
        });
    };


    var _saveAsset = function (Asset) {
      

        return $http.post(serviceBase + 'api/Asset/PostAsset', Asset).then(function (response) {
            return response;
        });

    };


    var _getCategory = function () {

        return $http.get(serviceBase + 'api/Category').then(function (results) {
            return results;
        });
    };


    var _saveCategory = function (Category) {
      

        return $http.post(serviceBase + 'api/Category/PostCategory', Category).then(function (response) {
            return response;
        });

    };

    var _getExpense = function () {

        return $http.get(serviceBase + 'api/Expense').then(function (results) {
            return results;
        });
    };


    var _saveExpense = function (Expense) {
      

        return $http.post(serviceBase + 'api/Expense/PostExpense', Expense).then(function (response) {
            return response;
        });

    };

    var _getIncoming = function () {

        return $http.get(serviceBase + 'api/Incoming').then(function (results) {
            return results;
        });
    };


    var _saveIncoming = function (Incoming) {
       

        return $http.post(serviceBase + 'api/Incoming/PostIncoming', Incoming).then(function (response) {
            return response;
        });

    };

    ordersServiceFactory.getOrders = _getOrders;
    ordersServiceFactory.getProjects = _getProjects;
    ordersServiceFactory.saveProject = _saveProject;
    ordersServiceFactory.getAssets = _getAssets;
    ordersServiceFactory.saveAsset = _saveAsset;
    ordersServiceFactory.getCategory = _getCategory;
    ordersServiceFactory.saveCategory = _saveCategory;
    ordersServiceFactory.getExpense = _getExpense;
    ordersServiceFactory.saveExpense = _saveExpense;
    ordersServiceFactory.getIncoming = _getIncoming;
    ordersServiceFactory.saveIncoming = _saveIncoming;
    

    return ordersServiceFactory;

}]);