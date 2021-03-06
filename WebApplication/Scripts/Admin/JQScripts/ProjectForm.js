﻿$(document).on("change", "#addCategorys", function () {
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
                $("#SubCategoryId").append('<option value="">  -----Select Sub Catrgory-----  </option>');
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
    //event.preventDefault();
    var form = $('#ProjectForm')[0];
    var dataString = new FormData(form);
    var selectedImages = [];
    $(".file-footer-caption").each(function() {
        selectedImages.push($(this).text());
    });
    $("#imagesNames").val(selectedImages);
    //$.ajax({
    //    url: "/Admin/ProjectForm",
    //    type: "POST",
    //    async: true,
    //    data: { input: $('#ProjectForm').serialize(), imagesNames: selectedImages },
    //    contentType: false,
    //    processData: false,
    //    cache: false,
    //    success: function (data) {
    //        //$("#addCategorys").append('<option value="' + data.Id + '">' + data.Name + '</option>');
    //        //$("#CategoryModel").modal("hide");
    //        //$.get("/Admin/ProjectForm", function (data2) {
    //        //});

    //    },
    //    error: function (xhr) {
    //        alert('error');
    //    }
    //});
});

$(document).on("click", "#btnSubmitSub", function (event) {
    $(".subcatdata :selected").text();
    var value = $("#addCategorys :selected").val();
    $("#SubForm #CategoryId").val(value);
    //alert($("#SubForm #CategoryId").val());
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
            //alert(JSON.stringify(data));
            $("#SubCategoryId").append('<option value="' + data.Id + '">' + data.Name + '</option>');            
            $("#SubCatModal").modal("hide");
            $.get("/Admin/ProjectForm", function (data2) {
            });
        },
        error: function (xhr) {
            alert('error');
        }
    });
});


$(document).on("click", "#btnaddcategory", function (event) {
    var form = $('#CategoryForm')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: "/Admin/addCategory",
        type: "POST",
        async: true,
        data: dataString,
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

$('#CategoryModel').on('hidden.bs.modal', function () {
    $("#CatName").val("");
});

$('#SubCatModal').on('hidden.bs.modal', function () {
    $("#SSubCatName").val("");
});

$(document).on("change", "#addCategorys", function(event) {
    //var Id = $("#addCategorys").val();
    //alert(Id);
    //alert($(this).val());
    if ($("#addCategorys").val() != "") {
        $(".catclass").show();
    } else {
        $(".catclass").hide();
    }
});

$(document).on("change", "#SubCategoryId", function(event) {
    //var Id = $("#addCategorys").val();
    ////alert(Id);
    //alert($(this).val());
    if ($("#SubCategoryId").val() != "") {
        $(".Subclass").show();
    } else {
        $(".Subclass").hide();
    }
});

$(document).on("click", "#deleteCategory", function (event) {
    var Id = $("#addCategorys").val();   
    $.ajax({
        url: "/Admin/DeleteCategory/" + Id,
        type: "GET",
        async: true,
        data: Id,
        contentType: false,
        processData: false,
        cache: false,
        success: function (list) {
            // alert(JSON.stringify(subCategory));
            $("#addCategorys").html(""); // clear before appending new list 
            $("#addCategorys").append('<option>  -----Select Catrgory-----  </option>');
            $.each(list, function (i, list) {
                $("#addCategorys").append('<option value="' + list.Id + '">' + list.Name + '</option>');
            });
            $("#addCategorys").change();
            $("#DeleteCatModal").modal("hide");
        },
        error: function (xhr) {
            alert('error');
        }
    });
});


$(document).on("click", "#deleteSubCategory", function (event) {
    var Id = $("#SubCategoryId").val();  
    $.ajax({
        url: "/Admin/DeleteSubCategory/"+Id,
        type: "GET",
        async: true,
        data: Id,
        contentType: false,
        processData: false,
        cache: false,
        success: function (list) {
            $("#SubCategoryId").html(""); // clear before appending new list 
            $("#SubCategoryId").append('<option>  -----Select Sub Catrgory-----  </option>');
            $.each(list, function (i, list) {
                $("#SubCategoryId").append('<option value="' + list.Id + '">' + list.Name + '</option>');
            });
            $("#SubCategoryId").change();
            $("#DeleteSuCatModal").modal("hide");
        },
        error: function (xhr) {
            alert('error');
        }
    });
});

$(document).on("click", ".DelCatModel", function (e) {
    var Id = $("#addCategorys").val();
    var text = $("#addCategorys :selected ").text();
    //alert(Id);
    //alert(text);
    $(".DelCat").attr(Id);
    $(".catnametext").empty();
    $(".catnametext").append("Are You Sure You Want To Delete: " + text);

    $.ajax({
        url: "/Admin/ChecProjectCat/" + Id,
        type: "GET",
        async: true,
        data: Id,
        contentType: false,
        processData: false,
        cache: false,
        success: function (ptoj) {
            if (ptoj > 0) {
                alert("You Can`t Delete This Category Because It Has " + ptoj + " Project Related ");
            }
            else { 
                $("#DeleteCatModal").modal("show");
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
   
});



$(document).on("click", ".DelSubCatModel", function (e) {
    var Id = $("#SubCategoryId").val();
    var text = $("#SubCategoryId :selected ").text();
    $(".Subcatnametext").empty();
    $(".Subcatnametext").append("Are you sure you want to delete: " + text);
    $.ajax({
        url: "/Admin/ChecProjectSubCat/" + Id,
        type: "GET",
        async: true,
        data: Id,
        contentType: false,
        processData: false,
        cache: false,
        success: function (ptoj) {
            if (ptoj > 0) {
                alert("You Can`t Delete This Sub Category Because It Has " + ptoj + " Project Related ");
            }
            else {
                $("#DeleteSuCatModal").modal("show");
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });

});