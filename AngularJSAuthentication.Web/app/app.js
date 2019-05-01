
var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });    

    $routeProvider.when("/project", {
        controller: "projectController",
        templateUrl: "/app/views/project.html"
    });

    $routeProvider.when("/assets", {
        controller: "AssetsController",
        templateUrl: "/app/views/Asset.html"
    });

    $routeProvider.when("/category", {
        controller: "CategoryController",
        templateUrl: "/app/views/Category.html"
    });

    $routeProvider.when("/expense", {
        controller: "ExpenseController",
        templateUrl: "/app/views/expense.html"
    });

    $routeProvider.when("/incoming", {
        controller: "incomingController",
        templateUrl: "/app/views/incoming.html"
    });

    $routeProvider.when("/supplier", {
        controller: "SupplierController",
        templateUrl: "/app/views/Supplier.html"
    });

    $routeProvider.when("/manufacturer", {
        controller: "ManufacturerController",
        templateUrl: "/app/views/Manufacturer.html"
    });

    $routeProvider.otherwise({ redirectTo: "/login" });

});

var serviceBase = 'http://localhost:26264/';

//var serviceBase = 'http://hms.shivamitconsultancy.com/';


//var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


