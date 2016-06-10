app.controller('AuthController', [
  '$http',
  '$scope',
  'AuthFactory',
  function($http, $scope, authFactory) {
    $scope.githubOAuth = function() {
      OAuth.initialize('1LjMtJfFr0UOsXw4mN0BWMYheZc')
      OAuth.popup('github').done(function(result) {
        console.log('result', result);
        // do some stuff with result
        result.me().done(function(data) {
          console.log('data', data);
        })
      })
    }
  }
])
