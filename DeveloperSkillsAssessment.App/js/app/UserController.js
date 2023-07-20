angular.module('app')
    .controller('UsrCtrl', ['$scope', '$http', '$window', '$rootScope', 'SharedDataService', function ($scope, $http, $window, $rootScope, SharedDataService) {
        $scope.PersonID = localStorage.getItem('PrsnID');
        $scope.accountID = localStorage.getItem('AccId');

        $scope.pageSize = 10; // Number of persons per page
        $scope.currentPage = 1; // Current page number
        $scope.persons = []; // Initialize persons array
        $scope.closed = [false, true];


        $scope.editPerson = {}; // Object to store the person data for editing

        // Function to show the edit modal
        $scope.showEditModal = function (person) {
            $scope.editPerson = angular.copy(person);
            document.getElementById('editModal').style.display = 'block';
        };

        // Function to show the edit modal
        $scope.showEditModal2 = function (acc) {
            $scope.editAcc = angular.copy(acc);
            document.getElementById('editModal').style.display = 'block';
        };
        // Function to show the edit modal
        $scope.showEditModal3 = function (tran) {
            $scope.editTran = angular.copy(tran);
            document.getElementById('editModal').style.display = 'block';
        };

        // Function to show the insert modal
        $scope.showInsertModal = function (person) {
            $scope.insertPerson = angular.copy(person);
            document.getElementById('insertModal').style.display = 'block';
        };

        $scope.showInsertModal2 = function (p) {
            $scope.pCode = p;
            document.getElementById('insertModal2').style.display = 'block';
        };

        // Function to hide the edit modal
        $scope.hideEditModal = function () {
            document.getElementById('editModal').style.display = 'none';
        };
        // Function to hide the insert modal
        $scope.hideInsertModal = function () {
            document.getElementById('insertModal').style.display = 'none';
        };

        // Function to hide the insert modal
        $scope.hideInsertModal2 = function () {
            document.getElementById('insertModal2').style.display = 'none';
        };

        // Function to convert input to uppercase
        $scope.convertToUppercase = function (person, field) {
            person[field] = person[field].toUpperCase();
        };

        $scope.persons = $http.get(SharedDataService.APIEndpoint + '/api/Persons/GetPersons')
            .then(function (response) {
                $scope.persons = response.data;
            });
        $scope.trans = $http.get(SharedDataService.APIEndpoint + '/api/Transactions/GetTrans', { params: { AccCode: $scope.accountID } })
            .then(function (response) {
                $scope.trans = response.data;
            });

        $scope.accounts = $http.get(SharedDataService.APIEndpoint + '/api/Users/GetAccounts', { params: { PersonCode: $scope.PersonID } })
            .then(function (response) {
                $scope.accounts = response.data;
            });

        $scope.DeleteUsr = function (iDNum) {
            var entryData = {
                IDNum: iDNum
            };

            $http.put(SharedDataService.APIEndpoint + '/api/Users/DeleteUser', null, {
                params: entryData
            })
                .then(function (response) {
                    // Handle the response
                    console.log('User deleted successfully');
                })
                .catch(function (error) {
                    // Handle the error
                    console.log('Error deleting user!', error);
                });
        };

        $scope.EditUsr = function (iDNum,Name,Surn) {
            var entryData = {
                IDNum: iDNum,
                Name:Name,
                Surname:Surn
            };

            $http.put(SharedDataService.APIEndpoint + '/api/Users/EditUser', null, {
                params: entryData
            })
                .then(function (response) {
                    // Handle the response
                    console.log('User updated successfully');
                    $scope.hideEditModal();
                })
                .catch(function (error) {
                    // Handle the error
                    console.log('Error updating user!', error);
                });
        };

        $scope.EditAcc = function (AccNum, OutStan, Clsd,Stat) {
            var entryData = {
                AccNum: AccNum,
                OutStan: OutStan,
                Closed: Clsd,
                Status:Stat

                /*string AccNum, decimal OutStan, Boolean Closed, string Status*/
            };

            $http.put(SharedDataService.APIEndpoint + '/api/Account/EditAcc', null, {
                params: entryData
            })
                .then(function (response) {
                    // Handle the response
                    console.log('Account updated successfully');
                    $scope.hideEditModal();
                })
                .catch(function (error) {
                    // Handle the error
                    console.log('Error updating account!', error);
                });
        };

        $scope.EditTrans = function (Acc,amt,descr) {
            var entryData = {
                AccCode: Acc,
                amount: amt,
                des: descr
            };

            $http.put(SharedDataService.APIEndpoint + '/api/Transactions/EditTrans', null, {
                params: entryData
            })
                .then(function (response) {
                    // Handle the response
                    console.log('Transaction updated successfully');
                    $scope.hideEditModal();
                    location.reload();
                })
                .catch(function (error) {
                    // Handle the error
                    console.log('Error updating Transaction!', error);
                });
        };

        $scope.CreateUsr = function (iDNum, Name, Surn) {
            var entryData = {
                IDNum: iDNum,
                Name: Name,
                Surname: Surn
            };

            $http.post(SharedDataService.APIEndpoint + '/api/Users/InsertUser', null, {
                params: entryData
            })
                .then(function (response) {
                    // Handle the response
                    console.log('User inserted successfully');
                    $scope.hideInsertModal();
                })
                .catch(function (error) {
                    // Handle the error
                    console.log('Error inserting user!', error);
                });
        };

        $scope.CreateTrans = function (tran,amt,des) {
            var entryData = {
                AccCode: $scope.accountID,
                transd: tran,
                amount: amt,
                des:des
            };

            $http.post(SharedDataService.APIEndpoint + '/api/Transactions/InsertTrans', null, {
                params: entryData
            })
                .then(function (response) {
                    // Handle the response
                    console.log('Transaction inserted successfully');
                    $scope.hideInsertModal();
                })
                .catch(function (error) {
                    // Handle the error
                    console.log('Error inserting Transaction!', error);
                });
        };

        $scope.AccStat = $http.get(SharedDataService.APIEndpoint + '/api/AccountStatus/GetStats')
            .then(function (response) {
                $scope.AccStat = response.data;
            });

        $scope.CreateAcc = function (num, otStand, stat) {
            var entryData = {
                PersonC: $scope.pCode,
                AccNum: num,
                OutStanding: otStand,
                status:stat
            };

            $http.post(SharedDataService.APIEndpoint + '/api/Account/InsertAcc', null, {
                params: entryData
            })
                .then(function (response) {
                    // Handle the response
                    console.log('Account inserted successfully');
                    $scope.hideInsertModal2();
                })
                .catch(function (error) {
                    // Handle the error
                    console.log('Error inserting account!', error);
                });
        };

        //Page redirects
        $scope.openAccounts = function (id) {
            // Perform the page redirect
            localStorage.setItem('PrsnID', id);
            $window.location.href = '/Views/DevSkillAss/PersonDetails.html';
        };

        $scope.openTrans = function (c) {
            // Perform the page redirect
            localStorage.setItem('AccId', c);
            $window.location.href = '/Views/DevSkillAss/Transactions.html';
        };
        
    }]);