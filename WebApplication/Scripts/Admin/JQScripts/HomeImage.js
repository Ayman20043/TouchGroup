$(document).on('ready', function () {
    $("#PicturePath").fileinput({
        previewFileType: "image",
        browseClass: "btn btn-success",
        browseLabel: "Pick Image",
        browseIcon: "<i class=\"glyphicon glyphicon-picture\"></i> ",
        removeClass: "btn btn-danger",
        removeLabel: "Delete",
        removeIcon: "<i class=\"glyphicon glyphicon-trash\"></i> ",
        uploadClass: "btn btn-info",
        uploadLabel: "Upload",
        uploadIcon: "<i class=\"glyphicon glyphicon-upload\"></i> "
    });
});

$(document).ready(function () {
    $('#DataModal').on('hidden.bs.modal', function () {
        $('#form2')[0].reset();
        $('#form2').parsley().reset();
    });
});

$(document).on("click", ".add", function (e) {
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
        url: "/Admin/GetHomeImage?id=" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            var aymoseba = "/Images/backgrounds/SmallBackGround/" + data.PicturePath + "_S." + data.Extention;
            $("#Picture").attr("Src", aymoseba);
            $("#Title").val(data.Title);
            $("#Description").val(data.Description);
            //$("#PicturePath").val(data.PicturePath);
            $("#IsActive").prop('checked',Boolean(data.IsActive));
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
                url: "/Admin/CreatHome",
                type: "POST",
                async: true,
                data: dataString,
                contentType: false,
                processData: false,
                cache: false,
                success: function (data) {
                    $("#DataModal").modal("hide");
                    $.get("/Admin/GetHomePartial", function (data2) {
                        $("#HomePartial").html(data2);
                    });
                    $("#PicturePath").empty();
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
            url: "/Admin/SaveHomeImages",
            type: "POST",
            async: true,
            data: dataString,
            contentType: false,
            processData: false,
            cache: false,
            success: function (data) {
                $("#DataModal").modal("hide");
                $.get("/Admin/GetHomePartial", function (data2) {
                    $("#HomePartial").html(data2);
                });
                $("#PicturePath").empty();
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
        url: "/Admin/DeleteElemnt?id=" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            $("#DeleteModel").modal("hide");
            $.get("/Admin/GetHomePartial", function (data2) {
                $("#HomePartial").html(data2);
            });

        },
        error: function (xhr) {
            alert('error');
        }
    });
});


$(document).ready(function () {
    $(document).on("click", ".clickdelete", function (e) {
        var action = $(this).attr('data-id');
        $(".btndel").attr('data-id', action);
        $("#DeleteModel").modal("show");
    });
});
