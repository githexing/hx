$(document).ready(function () {
    var options = {
        beforeSubmit: showRequest,
        success: showResponse,
        dataType: 'json',
        clearForm: true,
        error: function (request, message, ex) {
            alert('错误：' + message);
        }
    };
    $('#qrForm').ajaxForm(options);
});
function showRequest(formData, jqForm, options) {
    return true;
}
function showResponse(responseText, statusText, xhr, $form) {
    if (responseText[0].count == 0) {
        alert(responseText[0].list[0].error);
        return false;
    }
    $("#img_qr").attr("src", responseText[0].list[0].imgurl);
    $("#txt_readqr").val(responseText[0].list[0].qrtext);
    return false;

}
function getQrImg() {
    var txt_qr = escape($.trim($("#txt_qr").val()));
    var qrEncoding = $("#Encoding").val();;
    var Level = $("#Level").val();;
    var txt_ver = $("#txt_ver").val();;
    var txt_size = $("#txt_size").val();;
    $.ajax({
        type: "GET",
        data: "cmd=set&txt_qr=" + txt_qr + "&qrEncoding=" + qrEncoding + "&Level=" + Level + "&txt_ver=" + txt_ver + "&txt_size=" + txt_size,
        url: "Ashx/test.ashx",
        dataType: 'text',
        beforeSend: function (x) {
            x.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
        },
        success: function (json) {
            var dataObj = eval(json);
            $("#qrimg").attr("src", dataObj[0].list[0].imgurl);
            return false;
        },
        error: function (request, message, ex) {
            alert("错误：" + message);
        }
    });
}