﻿(function ($) {    function UserAttendance() {        var $this = this;        function initializeGetApprovel() {            $('#NavRole').click(function () {   //Here we create a EventClick method                $.ajax({                    type: 'GET',                    url: "/HrmsRole/AddRole",                    success: function (data) {                        $("#ClickAttendanceApprovel .modal-body").html(data);                        $("#ClickAttendanceApprovel").modal('show');                    },                    error: function (er) {                        console.log(er)                    }                });            })        }        $this.init = function () {            initializeGetApprovel();        };    }    $(function () {        var self = new UserAttendance();        self.init();    });}(jQuery));