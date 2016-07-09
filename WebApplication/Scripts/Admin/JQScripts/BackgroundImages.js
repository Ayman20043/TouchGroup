$(document).ready(function () {
    $('#DataModal').on('hidden.bs.modal', function () {
        $('#form2')[0].reset();
    });

});

$(document).on("click", ".edite", function (e) {
    $("#btnSubmit").text('Save').css("background-color", "#337ab7").addClass("White");
    var action = $(this).attr('data-id');
    alert(action);
    $("#DataModal").modal("show");
    $("#hdnId").val(action);
    $("#Id").val(action);
    $("#Picture").show();
    $.ajax({
        url: "/Admin/GetBackroundImage/" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            //var aymoseba = "/Images/backgrounds/PagesWallpapers/" + data.PicturePath + "_S." + data.Extention;
            //$("#Picture").attr("Src", aymoseba);
            //$("#ColorPickerInput").setColor("#" + data.TitleColor);
            //$("#ColorPickerInput").val("#" + data.TitleColor);
            //$('#ColorPickerInput').colorpicker({
            //    color: "#" + data.TitleColor,
            //    format: 'hex'
            //});
            //$("#ColorPickerInput").trigger('change');


        },
        error: function (xhr) {
            alert('error');
        }
    });

});