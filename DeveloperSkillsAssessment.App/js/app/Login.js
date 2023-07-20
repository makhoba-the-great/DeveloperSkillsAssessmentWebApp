angular.module('app')
    .controller('LoginCtrl', ['$scope', '$http', '$window', '$rootScope', 'SharedDataService', function ($scope, $http, $window, $rootScope, SharedDataService) {
    //Login Varables
    $scope.username = '';
    $scope.password = '';
    $scope.showMessage = false;
    $scope.responseError = false;

    $scope.login = function () {
        var loginData = {
            Username: $scope.username,
            Password: $scope.password
        };

        $http.get(SharedDataService.APIEndpoint+'/api/Users/SubmitLogs', { params: loginData })
            .then(function (response) {
                //debugger;
                if (response.data.length === 0) {
                    // Incorrect username or password, show error message
                    $scope.showMessage = true;
                    $scope.responseError = true;
                    /*alert('Login unsuccessful!');*/
                    //debugger;
                } else {
                    // Correct username or password
                        $window.location.href = '/Views/DevSkillAss/PersonsMain.html';
                }
            })
            .catch(function (error) {
                $scope.showMessage = true;
                $scope.responseError = true;
                console.log(error);
            });
    };

        //Error pop up js START
        // Open the error pop-up
        function showErrorPopup() {
            document.getElementById("errorPopup").style.display = "block";
        }

        // Close the error pop-up
        function closeErrorPopup() {
            document.getElementById("errorPopup").style.display = "none";
        }

        // Attach click event to close button
        document.querySelector(".error-popup-content .close").addEventListener("click", closeErrorPopup);

        // Add an event listener to the form submission
        document.getElementById("myForm").addEventListener("submit", function (event) {
            event.preventDefault();
            // Add your logic to check username and password here
            // If the login is incorrect, call the showErrorPopup() function
            showErrorPopup();
        });

        //Pop up END
}]);