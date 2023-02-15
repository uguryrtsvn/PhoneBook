const baseUrl = window.location.origin;

const UpdateModalOpen = (phone, name, id) => {
    $("#phoneInfoId").val(id);
    $("#phone").val(phone);
    $("#name").val(name);
    $("#updateModal").css("display", "block");

}
const UpdatePhoneInfo = () => {
    const obj = {
        belge_no: invoiceNo,
        sube: $("#branchCode").val(),
        bolum: $("#sectionNo").val(),
        tip: "C"
    };

    $.ajax({
        method: "post",
        url: baseUrl + "/Home/CreatePhoneInfo",
        async: false,
        datatype: 'json',
        data: obj,
        contenttype: 'application/json; charset=utf-8',
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        },
        success: function (response, statustext, jqxhr) {
            $("#table").html(response);
            $('#invoicePage').css('display', 'none');
            sellerCode = $('#sellerCode').val();
            $("#mainInput").focus();
        },
        error: function (response, statustext, jqxhr) {

            alert(statustext);
        }
    });
}
const CreateModalOpen = () => { 
    $("#createModal").addClass("show"); 
    $("#createModal").css("display", "block"); 
}

const CreateModalClose = () => {
    $("#createModal").removeClass("show");
    $("#createModal").css("display", "none");
}



const CreatePhoneInfo = () => {
    const obj = { 
        bookId: $("#BookId").val(),
        phoneNumber: $("#cphone").val(),
        fullName: $("#cname").val()
    };
    if (obj.bookId == null || obj.phoneNumber == null || obj.fullName == null) {
        notyf.error("Kişi bilgileri boş olamaz.");
        return;
    }
    $.ajax({
        method: "post",
        url: baseUrl + "/Home/CreatePhoneInfo",
        async: false,
        datatype: 'json',
        data: obj,
        contenttype: 'application/json; charset=utf-8',
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        },
        success: function (response, statustext, jqxhr) {
            $("#rehber").html(response);
            notyf.success("Kişi rehbere eklendi.");
        },
        error: function (response, statustext, jqxhr) {

            notyf.error("Kişi rehbere eklenemedi. Tekrar deneyiniz.");
        }
    });
}