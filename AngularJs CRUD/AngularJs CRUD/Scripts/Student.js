var app = angular.module("myApp", []);

app.controller("myCntrl", function ($scope, $http) {
    var vm = this;
    vm.student = {

    };
    vm.btntext = "Submit";
    vm.addStudent = function () {
        var type = document.getElementById("Inserted").getAttribute("value");
        if (type == "Submit") {
            btntext = "Please Wait...";
            $http({
                method: "POST",
                url: "/Home/AddStudent",
                data: vm.student
            }).then(function (d) {
                btntext = "Submit";
                vm.student = null;
                vm.GetRecord();
            }),
                (function (d) {
                    alert(d.data);
                })
        } else {
            btntext = "Please Wait...";
            $http({
                method: "POST",
                url: "/Home/Update",
                data: vm.student
            }).then(function (d) {
                vm.btntext = "Submit";
                vm.student = null;
                vm.GetRecord();
            }),
                (function (d) {
                    alert(d.data);
                })
        }
    }
    vm.GetRecord = function () {
        $http.get("/Home/GetRecord").then(function (d) {
            vm.RegisteredData = d.data;
        }, function (error) {
            alert("Failed");
        });
    };
    vm.UpdateDetails = function (Std) {
        vm.student.id = Std.ID;
        vm.student.Name = Std.Name;
        vm.student.Fname = Std.Fname;
        vm.student.Email = Std.Email;
        vm.student.Mobile = Std.Mobile;
        vm.student.Description = Std.Description;
        vm.btntext = "Update";
    }
    vm.DeleteDetails = function (id) {
        $http({
            method: "post",
            url: "/Home/Delete",
            datatype: "json",
            data: {id: id},
        }).then(function (response) {
            alert(response.data);
            vm.GetRecord();
        })
    };

    vm.GetRecord();
})