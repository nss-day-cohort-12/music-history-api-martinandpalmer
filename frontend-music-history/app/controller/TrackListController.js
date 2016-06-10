app.controller('TrackListController', [
  '$http',
  '$scope',
  function ($http, $scope) {

    $scope.tracks = [];

    $scope.filterArtistString = null;

    $http
      .get('http://localhost:5000/api/Track')
      .then(
        resolve => {
          let APItracks = resolve.data;
          $scope.tracks = APItracks;
          console.log('APItracks', APItracks);
        },
        reject => console.log(reject)
      );
}])
