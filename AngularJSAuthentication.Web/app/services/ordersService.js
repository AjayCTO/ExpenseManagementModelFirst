'use strict';
app.factory('ordersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

  

    var ordersServiceFactory = {};

    var _getOrders = function () {
        return $http.get(serviceBase + 'api/orders').then(function (results) {
            return results;
        });
    };


    ///////////////////////////////////////////////////////////////////////////////

    var _getProjects = function () {
        return $http.get(serviceBase + 'api/Project').then(function (results) {          
            return results;
        });
    };


    var _getProjectByID = function (id) {
        return $http.get(serviceBase + 'api/Project/GetProject', { params: { id: id } }).then(function (results) {
            return results;
        });
    };

    var _saveProject = function (project) {  
        return $http.post(serviceBase + 'api/Project/PostProject', project).then(function (response) {
            return response;
        });
    };

    var _updateProject = function (project) {
        return $http.put(serviceBase + 'api/Project/PutProject', project).then(function (response) {
            return response;
        });
    };


    var _deleteProject = function (id) {
        return $http.delete(serviceBase + 'api/Project/DeleteProject', { params: { id: id } }).then(function (results) {
            return results;
        });
    };


    //////////////////////////////////////////////////////////////////////////////////////////////

    var _getAssets = function () { 
        return $http.get(serviceBase + 'api/Asset').then(function (results) {
            return results;
        });
    };


    var _getAssetsByID = function (id) {
        return $http.get(serviceBase + 'api/Asset/GetAsset', { params: { id: id } }).then(function (results) {
            return results;
        });
    };

    var _deleteAsset = function (id) {
        return $http.get(serviceBase + 'api/Asset/DeleteAsset', { params: { id: id } }).then(function (results) {
            return results;
        });
    };



    var _saveAsset = function (Asset) {     
        return $http.post(serviceBase + 'api/Asset/PostAsset', Asset).then(function (response) {
            return response;
        });
    };


    var _updateAsset = function (Asset) {
        return $http.put(serviceBase + 'api/Asset/PutAsset', Asset).then(function (response) {
            return response;
        });
    };

    /////////////////////////////////////////////////////////////////////

    var _getCategory = function () {
        return $http.get(serviceBase + 'api/Category').then(function (results) {
            return results;
        });
    };

    var _getCategoryByID = function (id) {
        return $http.get(serviceBase + 'api/Category/GetCategory', { params: { id: id } }).then(function (results) {
            return results;
        });
    };

    var _deleteCategory = function (id) {
        return $http.delete(serviceBase + 'api/Category/DeleteCategory', { params: { id: id } }).then(function (results) {
            return results;
        });
    };


    var _saveCategory = function (Category) {
        return $http.post(serviceBase + 'api/Category/PostCategory', Category).then(function (response) {
            return response;
        });
    };


    var _updateCategory = function (Category) {
        return $http.put(serviceBase + 'api/Category/PutCategory', Category).then(function (response) {
            return response;
        });
    };


    //////////////////////////////////////////////////////////////////////////////


    var _getExpense = function () {
        return $http.get(serviceBase + 'api/Expense').then(function (results) {
            return results;
        });
    };


    var _getExpenseByID = function (id) {
        return $http.get(serviceBase + 'api/Expense/GetExpense', { params: { id: id } }).then(function (results) {
            return results;
        });
    };

    var _saveExpense = function (Expense) {      
        return $http.post(serviceBase + 'api/Expense/PostExpense', Expense).then(function (response) {
            return response;
        });
    };


    var _updateExpense = function (Expense) {
        return $http.put(serviceBase + 'api/Expense/PutExpense', Expense).then(function (response) {
            return response;
        });
    };

    var _deleteExpense = function (id) {
        return $http.delete(serviceBase + 'api/Expense/deleteExpense', { params: { id: id } }).then(function (results) {
            return results;
        });
    };



    //////////////////////////////////////////////////////////////////////////////////////////

    var _getIncoming = function () {
        return $http.get(serviceBase + 'api/Incoming').then(function (results) {
            return results;
        });
    };

  
    var _getIncomingByID = function (id) {
        return $http.get(serviceBase + 'api/Incoming/GetIncoming', { params: { id: id } }).then(function (results) {
            return results;
        });
    };

    var _saveIncoming = function (Incoming) {
        return $http.post(serviceBase + 'api/Incoming/PostIncoming', Incoming).then(function (response) {
            return response;
        });
    };


    var _updateIncoming = function (Incoming) {
        return $http.put(serviceBase + 'api/Incoming/PutIncoming', Incoming).then(function (response) {
            return response;
        });
    };


    var _deleteIncoming = function (id) {
        return $http.delete(serviceBase + 'api/Incoming/DeleteIncoming', { params: { id: id } }).then(function (response) {
            return response;
        });
    };

    ////////////////////////////////////////////////////////////////////

    var _getSupplier = function () {
        return $http.get(serviceBase + 'api/Supplier').then(function (results) {
            return results;
        });
    };


    var _getSupplierByID = function (id) {
        return $http.get(serviceBase + 'api/Supplier/GetSupplier', { params: { id: id } }).then(function (results) {
            return results;
        });
    };

    var _saveSupplier = function (Supplier) {
        return $http.post(serviceBase + 'api/Supplier/PostSupplier', Supplier).then(function (response) {
            return response;
        });
    };


    var _updateSupplier = function (Supplier) {
        return $http.put(serviceBase + 'api/Supplier/PutSupplier', Supplier).then(function (response) {
            return response;
        });
    };


    var _deleteSupplier = function (id) {
        return $http.delete(serviceBase + 'api/Supplier/DeleteSupplier', { params: { id: id } }).then(function (response) {
            return response;
        });
    };


    /////////////////////////////////////////////////////////////////////////////

    var _getManufacturer = function () {
        return $http.get(serviceBase + 'api/Manufacturer').then(function (results) {
            return results;
        });
    };


    var _getManufacturerByID = function (id) {
        return $http.get(serviceBase + 'api/Manufacturer/GetManufacturer', { params: { id: id } }).then(function (results) {
            return results;
        });
    };

    var _saveManufacturer = function (Manufacturer) {
        return $http.post(serviceBase + 'api/Manufacturer/PostManufacturer', Manufacturer).then(function (response) {
            return response;
        });
    };


    var _updateManufacturer = function (Manufacturer) {
        return $http.put(serviceBase + 'api/Manufacturer/PutManufacturer', Manufacturer).then(function (response) {
            return response;
        });
    };


    var _deleteManufacturer = function (id) {
        return $http.delete(serviceBase + 'api/Manufacturer/DeleteManufacturer', { params: { id: id } }).then(function (response) {
            return response;
        });
    };




    ordersServiceFactory.getOrders = _getOrders;


    ordersServiceFactory.getProjects = _getProjects;
    ordersServiceFactory.saveProject = _saveProject;
    ordersServiceFactory.getProjectByID = _getProjectByID;
    ordersServiceFactory.updateProject = _updateProject;
    ordersServiceFactory.deleteProject = _deleteProject;


    ordersServiceFactory.getAssets = _getAssets;
    ordersServiceFactory.saveAsset = _saveAsset;
    ordersServiceFactory.getAssetsByID = _getAssetsByID;
    ordersServiceFactory.updateAsset = _updateAsset;
    ordersServiceFactory.deleteAsset = _deleteAsset;


    ordersServiceFactory.getCategory = _getCategory;
    ordersServiceFactory.saveCategory = _saveCategory;
    ordersServiceFactory.getCategoryByID = _getCategoryByID;
    ordersServiceFactory.updateCategory = _updateCategory;
    ordersServiceFactory.deleteCategory = _deleteCategory;


    ordersServiceFactory.getExpense = _getExpense;
    ordersServiceFactory.saveExpense = _saveExpense;
    ordersServiceFactory.getExpenseByID = _getExpenseByID;
    ordersServiceFactory.updateExpense = _updateExpense;
    ordersServiceFactory.deleteExpense = _deleteExpense;


    ordersServiceFactory.getIncoming = _getIncoming; 
    ordersServiceFactory.saveIncoming = _saveIncoming;
    ordersServiceFactory.getIncomingByID = _getIncomingByID;
    ordersServiceFactory.updateIncomeing = _updateIncoming;
    ordersServiceFactory.deleteIncoming = _deleteIncoming;

    ordersServiceFactory.getManufacturer = _getManufacturer;
    ordersServiceFactory.saveManufacturer = _saveManufacturer;
    ordersServiceFactory.getManufacturerByID = _getManufacturerByID;
    ordersServiceFactory.updateManufacturer = _updateManufacturer;
    ordersServiceFactory.deleteManufacturer = _deleteManufacturer;

    ordersServiceFactory.getSupplier = _getSupplier;
    ordersServiceFactory.saveSupplier = _saveSupplier;
    ordersServiceFactory.getSupplierByID = _getSupplierByID;
    ordersServiceFactory.updateSupplier = _updateSupplier;
    ordersServiceFactory.deleteSupplier = _deleteSupplier;


    return ordersServiceFactory;

}]);