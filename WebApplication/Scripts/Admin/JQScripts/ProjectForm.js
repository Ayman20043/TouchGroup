$(document).on("change", "#addCategorys", function () {
    var CatId = $(this).val();
    //  alert(CatId);
    if (CatId != "") {
        $("#subDropDownDiv").show();
        $.ajax({
            url: '/Admin/Fill',
            type: "GET",
            dataType: "JSON",
            data: { id: CatId },
            success: function (subCategory) {
                // alert(JSON.stringify(subCategory));
                $("#SubCategoryId").html(""); // clear before appending new list 
                $("#SubCategoryId").append('<option>  -----Select Sub Catrgory-----  </option>');
                $.each(subCategory, function (i, subCategory) {
                    $("#SubCategoryId").append('<option value="' + subCategory.Id + '">' + subCategory.Name + '</option>');
                });
                $("#SubCategoryId").change();
            }
        });
    }
    else {
        $("#subDropDownDiv").hide();
    }

});

$(document).on('ready', function () {
    $("#LogoPath").fileinput({
        showUpload: false,
        showCaption: true,
        showRemove: false,
        showClose: false,
        browseClass: "btn btn-primary btn-md",
        fileType: "Image",
        previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
        previewSettings: { image: { width: "auto", height: "160px" } }
    });
});

$(document).on('ready', function () {
    $('.AddCat').click(function () {
        $('.modal-title').html("New Category");
        $('#CategoryModel').modal('show');
    });

//    $("#ProjectImages").fileinput({
//        uploadAsync: true,
//        uploadUrl: '/Admin/AsycnImageUpload',
//        deleteUrl: "/Admin/DeleteImage",
//        dataType: 'json',
//        autoUpload: true,
//        showUpload: false,
//        showCaption: true,
//        showRemove: false,
//        showClose: false,
//        maxFilePreviewSize: 10240
//    }).on("filebatchselected", function (event, files) {
//        // trigger upload method immediately after files are selected
//        $("#ProjectImages").fileinput("upload");
//    });
//});
//$('#ProjectImages').on('filepredelete', function (event, key) {
//    console.log('Key = ' + key);
//    alert("sdaas");
});

$(document).on('ready', function () {
    $('#AddsubCat').click(function () {
        $('.modal-title').html("New SubCategory");
        $('#SubCatModal').modal('show');
        $("#displayCat").text($("#addCategorys :selected").text());
    });
});

$(document).on("click", "#btnSubmit", function (event) {
    var form = $('#CategoryForm')[0];
    var dataString = new FormData(form);
    var selectedImages = [];
    $(".file-footer-caption").each(function() {
        selectedImages.push($(this).text());
    });
    $("#imagesNames").val(selectedImages);

    $.ajax({
        url: "/Admin/addCategory",
        type: "POST",
        async: true,
        data: { input: dataString, imagesNames:selectedImages },
        contentType: false,
        processData: false,
        cache: false,
        success: function (data) {
            $("#addCategorys").append('<option value="' + data.Id + '">' + data.Name + '</option>');
            $("#CategoryModel").modal("hide");
            $.get("/Admin/ProjectForm", function (data2) {
            });

        },
        error: function (xhr) {
            alert('error');
        }
    });
});

$(document).on("click", "#btnSubmitSub", function (event) {
    $(".subcatdata :selected").text();
    var value = $("#addCategorys :selected").val();
    $("#SubForm #CategoryId").val(value);
    alert($("#SubForm #CategoryId").val());
    var form = $('#SubForm')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: "/Admin/addSubCategory",
        type: "POST",
        async: true,
        data: dataString,
        contentType: false,
        processData: false,
        cache: false,
        success: function (data) {
            alert(JSON.stringify(data));
            $("#addCategorys").append('<option value="' + data.Id + '">' + data.Name + '</option>');
            $("#CategoryModel").modal("hide");
            $.get("/Admin/ProjectForm", function (data2) {
            });
        },
        error: function (xhr) {
            alert('error');
        }
    });
});
