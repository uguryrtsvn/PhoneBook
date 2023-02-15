const baseUrl = window.location.origin;

const UpdateModalOpen = (phone, name, id) => {
    $("#phoneInfoId").val(id);
    $("#phone").val(phone);
    $("#name").val(name);
    $("#updateModal").addClass("show"); 
    $("#updateModal").css("display", "block"); 
}

const CreateModalOpen = () => { 
    $("#createModal").addClass("show"); 
    $("#createModal").css("display", "block"); 
}

const ModalClose = (modalName) => {
    $(modalName).removeClass("show");
    $(modalName).css("display", "none");
    if (modalName == "#createModal") {
        $("#cphone").val("");
        $("#cname").val("");
    }
}



const CreatePhoneInfo = () => {
    const obj = { 
        bookId: $("#BookId").val(),
        phoneNumber: $("#cphone").val(),
        fullName: $("#cname").val()
    };
    if (obj.bookId == "" || obj.phoneNumber == "" || obj.fullName == "") {
        notyf.error("Kişi bilgileri boş olamaz.");
        return;
    }
    $.ajax({
        method: "post",
        url: baseUrl + "/Home/CreatePhoneInfo",
        async: true,
        datatype: 'json',
        data: obj,
        contenttype: 'application/json; charset=utf-8',
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        },
        success: function (response, statustext, jqxhr) {
            $("#rehber").html(response);
            ModalClose("#createModal");
            notyf.success("Kişi rehbere eklendi.");

        },
        error: function (response, statustext, jqxhr) {

            notyf.error("Kişi rehbere eklenemedi. Tekrar deneyiniz.");
        }
    });
}
const DeletePhoneInfo = () => {
    const obj = { 
        id : $("#phoneInfoId").val(),
        bookId: $("#BookId").val()
    };
    if (obj.id == "" || obj.id == null) {
        notyf.error("Kişi silenemedi. Tekrar deneyiniz.");
        return;
    }
    $.ajax({
        method: "post",
        url: baseUrl + "/Home/DeletePhoneInfo",
        async: true,
        datatype: 'json',
        data: obj,
        contenttype: 'application/json; charset=utf-8',
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        },
        success: function (response, statustext, jqxhr) {
            $("#rehber").html(response); 
            notyf.success("Kişi rehberden silindi.");
            ModalClose("#updateModal");
        },
        error: function (response, statustext, jqxhr) {

            notyf.error("Kişi rehberden silinemedi. Tekrar deneyiniz.");
        }
    });
}

const UpdatePhoneInfo = () => {
    const obj = {
        id: $("#phoneInfoId").val(),
        phoneNumber: $("#phone").val(),
        fullName: $("#name").val(), 
        bookId: $("#BookId").val()
    }; 
    if (obj.bookId == "" || obj.phoneNumber == "" || obj.fullName == "") {
        notyf.error("Kişi bilgileri boş olamaz.");
        return;
    }
    $.ajax({
        method: "post",
        url: baseUrl + "/Home/UpdatePhoneInfo",
        async: true,
        datatype: 'json',
        data: obj,
        contenttype: 'application/json; charset=utf-8',
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        },
        success: function (response, statustext, jqxhr) {
            $("#rehber").html(response);
            ModalClose("#updateModal");
            notyf.success("Kişi güncellendi.");
        },
        error: function (response, statustext, jqxhr) {

            notyf.error("Kişi güncellenemedi. Tekrar deneyiniz.");
        }
    });
}