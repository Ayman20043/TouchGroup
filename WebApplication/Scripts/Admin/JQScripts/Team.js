    $(document).on("click", ".add", function (e) {
        $("#DataModal").modal("show");
    });


$(document).on("click", ".clickedit", function (e) {
    var action = $(this).attr('data-id');
    $("#DataModal").modal("show");
    $("#hdnId").val(action);
    $.ajax({
        url: "/Admin/GetMember?id=" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            $("#Name").val(data.Name);
            $("#Position").val(data.Position);
            $("#Details").val(data.Details);
            $("#Picture").val(data.PicturePath);
            $("#Cv").val(data.CvPath);
        },
        error: function (xhr) {
            alert('error');
        }
    });

});


//var fileUpload = $("#imgefile").get(0).files;
//var files = fileUpload.files;


//$(document).on("click", "#btnAdd", function (event) {
//    alert("");
//    var form_data = {
//        Name: $('#Name').val(),
//        Position: $('#Position').val(),
//        Details: $('#Details').val(),
//        PicturePath: $("#imgefile").get(0).files[0],
//        CvPath: $('#Cv').val()
//    };

//    if (window.FormData !== undefined) {  
  
//        var fileUpload = $("#imgefile").get(0);  
//        var files = fileUpload.files;  
              
//        // Create FormData object  
//        var fileData = new FormData();  
  
//        // Looping over all files and add it to FormData object  
//        for (var i = 0; i < files.length; i++) {  
//            fileData.append(files[i].name, files[i]);  
//        }  
              
//        // Adding one more key to FormData object  
//        fileData.append('Name', $('#Name').val()); 
//        $.ajax({
//            url: "/Admin/UploadFile",     
//            type: "POST",
//            async: true,
//            data: fileData,
//            processData: false,
//            cache: false,
//            success: function (data) {
//                $("#DataModal").modal("hide");
//                $.get("/Admin/GetTeamPartial", function (data2) {
//                    $("#Teampartial").html(data2);
//                });

//            },
//            error: function (xhr) {
//                alert('error');
//            }
//        });
//    } else {  
//        alert("FormData is not supported.");  
//    }  
//    //    $.ajax({
//    //     url: "/Admin/UploadFile",
//    //    dataType: "json",
//    //    type: "POST",
//    //    async: true,
//    //    data:form_data,
//    //    processData: false,
//    //    cache: false,
//    //    success: function (data) {
//    //        $("#DataModal").modal("hide");
//    //        $.get("/Admin/GetTeamPartial", function (data2) {
//    //            $("#Teampartial").html(data2);
//    //        });

//    //    },
//    //    error: function (xhr) {
//    //        alert('error');
//    //    }
//    //});

//    //$.post("/Admin/UploadFile", form_data, function (data) {
//    //    $("#DataModal").modal("hide");
//    //    $.get("/Admin/GetTeamPartial", function (data2) {
//    //        $("#Teampartial").html(data2);
//    //    });
//    //});

//});


$(document).on("click", "#btnSave", function (event) {
    var form_data = {
        Id: $('#hdnId').val(),
        Name: $('#Name').val(),
        Position: $('#Position').val(),
        Details: $('#Details').val(),
        PicturePath: $('#Picture').val(),
        CvPath: $('#Cv').val()
    };
    $.post("/Admin/Savemember", form_data, function (data) {
        $("#DataModal").modal("hide");
        $.get("/Admin/GetTeamPartial", function (data2) {
            $("#Teampartial").html(data2);
        });
    });

});


$(document).on("click", ".clickdelete", function (e) {
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
            $("#DataModal").modal("hide");
            $.get("/Admin/GetTeamPartial", function (data2) {
                $("#Teampartial").html(data2);
            });

        },
        error: function (xhr) {
            alert('error');
        }
    });

});

$(document).on("click", ".clickview", function (e) {
    var action = $(this).attr('data-id');
    $("#ViewModel").modal("show");
    $.ajax({
        url: "/Admin/GetMember?id=" + action,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            $("#Nameview").val(data.Name);
            $("#Positionview").val(data.Position);
            $("#Detailsview").val(data.Details);
            $("#Pictureview").val(data.PicturePath);
            $("#CvView").val(data.CvPath);
        },
        error: function (xhr) {
            alert('error');
        }
    });

});




$(document).on("click", ".btnupload", function (e) {
    var form = $('#demo-form2')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: "/Admin/UploadFile", 
        type: 'POST',
        xhr: function () { 
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload) { 
                myXhr.upload.addEventListener('progress', progressHandlingFunction,
				false);
            }
            return myXhr;
        },
        success: successHandler,
        error: errorHandler,
        complete: completeHandler,        
        data: dataString,
        cache: false,
        contentType: false,
        processData: false
    });
});