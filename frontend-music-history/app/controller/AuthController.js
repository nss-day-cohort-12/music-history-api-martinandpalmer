app.controller('AuthController', [
  '$http',
  '$scope',
  '$location',
  'AuthFactory',
  function($http, $scope, $location, authFactory) {
    $scope.githubOAuth = function() {
      OAuth.initialize('1LjMtJfFr0UOsXw4mN0BWMYheZc')
      OAuth.popup('github').done(function(result) {
        console.log('result', result);
        // do some stuff with result
        result.me().done(function(data) {
          if (data.id != null) {
            authFactory.setUser(data);
          }
          console.log('data', data);
          window.location.assign('/#/');
        })
      })
    }
  }
])
