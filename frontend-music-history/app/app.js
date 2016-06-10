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
      .otherwise('/');
}]);
