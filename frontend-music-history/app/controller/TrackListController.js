app.controller('TrackListController', [
  '$http',
  '$scope',
  'AuthFactory',
  function ($http, $scope, authFactory) {

    $scope.tracks = [];

    $scope.filterArtistString = null;

    APIURI = "http://localhost:5000/api/Track";
    if (authFactory.getUser().alias != null) {
      console.log(`Getting tracks only for ${authFactory.getUser().alias}`);
      APIURI += `?userName=${authFactory.getUser().alias}`;
    }

    $http
      .get(APIURI)
      .then(
        resolve => {
          let APItracks = resolve.data;
          $scope.tracks = APItracks;
          console.log('APItracks', APItracks);
        },
        reject => console.log(reject)
    );
}]);
