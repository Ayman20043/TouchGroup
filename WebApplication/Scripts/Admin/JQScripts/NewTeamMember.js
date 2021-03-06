﻿$(document).on("click", ".add", function (e) {
    $("#btnSubmit").text('Add').css("background-color", "#5cb85c").addClass("White");
    $("#DataModal").modal("show");
    $("#Picture").hide();
});


$(document).on("click", ".clickedit", function (e) {
    $("#btnSubmit").text('Save').css("background-color", "#337ab7").addClass("White");
    var action = $(this).attr('data-id');
    $("#DataModal").modal("show");
    $("#hdnId").val(action);
    $("#Id").val(action);
    $("#Picture").show();
    $.ajax({
        url: "/Admin/GetMember?id=" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            var aymoseba = "/Images/Profile/Display/" + data.PicturePath + "_S." + data.Extention;
            $("#Picture").attr("Src", aymoseba);
            $("#Name").val(data.Name);
            $("#Position").val(data.Position);
            $("#Details").val(data.Details);
            $("#Phone").val(data.Phone);
            $("#Email").val(data.Email);
            $("#Picture").val("");
            $("#Cv").val(data.CvPath);
        },
        error: function (xhr) {
            alert('error');
        }
    });

});

$(document).on("click", "#btnSubmit", function (event) {
    if (btnSubmit.textContent == "Add") {
        var form = $('#form2')[0];
        var dataString = new FormData(form);
        $.listen('parsley:field:validate', function () {
            validateFront();
        });
        var validateFront = function () {
            if (true === $('#form2').parsley().isValid()) {
                $('.bs-callout-info').removeClass('hidden');
                $('.bs-callout-warning').addClass('hidden');
                return true;
            } else {
                $('.bs-callout-info').addClass('hidden');
                $('.bs-callout-warning').removeClass('hidden');
                return false;
            }
        };
        $('#form2').parsley().validate();
        var isValid = validateFront();
        if (isValid) {
            $.ajax({
                url: "/Admin/CreatMember",
                type: "POST",
                async: true,
                data: dataString,
                contentType: false,
                processData: false,
                cache: false,
                success: function (data) {
                    $("#DataModal").modal("hide");
                    $.get("/Admin/GetPartial", function (data2) {
                        $("#NewTeamPartial").html(data2);
                    });
                    $(".loading").empty();
                },
                error: function (xhr) {
                    alert('error');
                }
            });
        } else {

        }

    }
    else {
        var form = $('#form2')[0];
        var dataString = new FormData(form);
        $.ajax({
            url: "/Admin/Savemember",
            type: "POST",
            async: true,
            data: dataString,
            contentType: false,
            processData: false,
            cache: false,
            success: function (data) {
                $("#DataModal").modal("hide");
                $.get("/Admin/GetPartial", function (data2) {
                    $("#NewTeamPartial").html(data2);
                });
                $(".loading").empty();
            },
            error: function (xhr) {
                alert('error');
            }
        });
    }
});

$(document).on("click", ".btndel", function (e) {
    var action = $(this).attr('data-id');
    $.ajax({
        url: "/Admin/DeleteRow?id=" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            $("#DeleteModel").modal("hide");
            $.get("/Admin/GetPartial", function (data2) {
                $("#NewTeamPartial").html(data2);
            });

        },
        error: function (xhr) {
            alert('error');
        }
    });

});

//$(document).on("click", ".view-pdf", function (e) {
//    var action = $(this).attr('data-id');
//    $("#Id").val(action);
//    $("#ViewModel").modal("show");
//    $.ajax({
//        url: "/Admin/GetMember?id=" + action,
//        dataType: "json",
//        type: "GET",
//        contentType: 'application/json; charset=utf-8',
//        async: true,
//        processData: false,
//        cache: false,
//        success: function (data) {
//            var aymoseba = "/File/" + data.CvPath;
//            $("#Cv").attr("href", aymoseba);
//        },
//        error: function (xhr) {
//            alert('error');
//        }
//    });

//});

$(document).ready(function () {
    $(document).on("click", ".clickdelete", function (e) {
        var action = $(this).attr('data-id');
        $(".btndel").attr('data-id', action);
        $("#DeleteModel").modal("show");
    });
});

$(document).ready(function () {
    $('#DataModal').on('hidden.bs.modal', function () {
        $('#form2')[0].reset();
        $('#form2').parsley().reset();
        $('#CvPath').fileinput('clear');
    });

});



