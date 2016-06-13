"use strict";

let app = angular.module("MusicHistory", [
  'ngRoute'
]);


app.config(['$routeProvider',
  function($routeProvider){
    $routeProvider
      .when('/', {
        templateUrl: 'partial/TrackList.html',
        controller: 'TrackListController'
      })
      .when('/login', {
        templateUrl: 'partial/Auth.html',
        controller: "AuthController"
      })
      .otherwise('/');
}]);


app.run([
  '$location',
  'AuthFactory',
  function($location, authFactory) {

    let isAuth = authFactory.getUser();

    if (!authFactory.getUser()) {
      $location.path('/login');
    }
}])
