$(document).on("change", "#CategoryId", function () {
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
    $('#AddCat').click(function () {
        $('.modal-title').html("New Category");
        $('#DataModal').modal('show');
    });



    $("#ProjectImages").fileinput({
        uploadUrl: '#',
        showUpload: false,
        showCaption: true,
        showRemove: false,
        showClose: false,
        maxFilePreviewSize: 10240
    });
});


$(document).on('ready', function () {
    $('#AddsubCat').click(function () {
        $('.modal-title').html("New SubCategory");
        $('#SubCatModal').modal('show');
    });
});

//$(document).ready(function() {
//    $("#LogoPath").fileinput({
//        showUpload: false,
//        showCaption: true,

//        browseClass: "btn btn-primary btn-md",
//        fileType: "Image",
//        previewFileIcon: "<i class='glyphicon glyphicon-king'></i>"
//    });
//});