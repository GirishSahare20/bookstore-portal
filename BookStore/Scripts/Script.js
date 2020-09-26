var app = angular
    .module("myModule", [])
    .controller("myController", function ($scope, $http) {
  
        $scope.loader = true;
        var url ="/Home/GetBookDetails"
        $http.get(url).then(function (response) {

            $scope.books = response.data;
            $scope.loader = false;
           // console.log(response.data);
        });


        $scope.objSearch = {
            "Name": "",
            "ISBN": "",
            "Author": "",
            "Description": ""
        }
         
        $scope.searchBookByParameters = function () {

            $scope.objSearch.Name = "Book1";
            var strObjSearch = angular.toJson($scope.objSearch);
            console.log(strObjSearch);
           // alert(strObjSearch);
            //$http({
            //    url: '/api/BookStore/',
            //    method: 'POST',
            //    params: { obj_search: strObjSearch }
            //}).then(function (data) {
            //    $scope.books = data;
            //    console.log(response.data);

            //}).error(function () {
            //        $scope.error = "An Error has occured while loading posts!";  });
            //$http({

            //    method: 'GET',

            //    url: '/api/values/'

            //}).then(function success(response) {

            //    console.log(response.data);
            //    alert(0);

            //}, function error(response) {

            //});

      

            var url = '/api/bookstore/', data = strObjSearch ,config = 'contenttype';
                $http.post(url, data, config).then(function (response) {
                    $scope.books = response.data;
                   console.log(response.data);
                   // alert(10);
                }, function (response) {
                        $scope.error = "An Error has occured while loading posts!";
                });
        }

        $scope.sortColumn = "Name";
        $scope.reverseSort = false;

        $scope.sortData = function (column) {
            $scope.reverseSort = ($scope.sortColumn == column) ?
                !$scope.reverseSort : false;
            $scope.sortColumn = column;
        }

        $scope.getSortClass = function (column) {

            if ($scope.sortColumn == column) {
                return $scope.reverseSort
                    ? 'arrow-down'
                    : 'arrow-up';
            }

            return '';
        }
    });