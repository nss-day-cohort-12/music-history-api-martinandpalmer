app.controller('TrackListController', [
  '$http',
  '$scope',
  function ($http, $scope) {

    $scope.tracks = {};

    $scope.filterArtistString = "artist";

    // $http
    //   .get('http://localhost:5000/api/Track')
    //   .success(APItracks => $scope.tracks = APItracks);
}])
