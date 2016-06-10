$(document).on('click', ".add", function (e) {
    window.location.href = "/Admin/AddCareer"
})

$(document).on("click", ".btndel", function (e) {
    var action = $(this).attr('data-id');
    $.ajax({
        url: "/Admin/DeleteJob?id=" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            $("#DeleteModel").modal("hide");
            $.get("/Admin/JobrPartial", function (data2) {
                $("#jobpartial").html(data2);
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

$(document).on("click", ".ViewDetails", function (e) {
    var action = $(this).attr('data-id');
    $("#ViewModel").modal("show");
    $.ajax({
        url: "/Admin/GetJob?id=" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            $("#xName").html(data.FullName);
            $("#xPosition").html(data.Position);
            $("#xphone").html(data.Phone);
            $("#xEmail").html(data.Email);
        },
        error: function (xhr) {
            alert('error');
        }
    });
});


$(document).on("click", ".viewCv", function (e) {
    $("#pdfmodal").modal("show");
    var action = $(this).attr('data-path');
    var fileName = "/File/JobCv" + action;
    $("#dialog").dialog();
    $('iframe').attr("src", fileName);
});