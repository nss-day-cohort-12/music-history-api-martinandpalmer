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
          /*
          POST new user to API. Currently API does not check for existing user. :/
          */
          $http({
            url: 'http://localhost:5000/api/AppUser',
            method: 'POST',
            data: JSON.stringify({
              Username: data.alias,
              Email: data.email
            })
          }).then(
            resolve => {
              let AppUser = resolve.data;
              console.log(`New App User ${AppUser}`);
            },
            reject => {
              console.log("Something went wrong. Perhaps the user is already created");
            });
          console.log('data', data);
          window.location.assign('/#/');
        })
      })
    }
  }
])
