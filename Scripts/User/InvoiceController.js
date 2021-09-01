(function () {
    app.controller("HomeInvoice", function ($scope, $http) {
        var init = function () {
            GetProducts();
        };
        init();
        function GetProducts() {
            $http.get("/User/GetAllProduct")
                .then(function (response) {
                    var data = response.data;
                    $scope.ProductList = data;
                });
        }
    })
}).call(angular);