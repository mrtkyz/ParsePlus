
$(function () {
    $('.file-upload').change(function () {
        var div = $(this).closest('.part').find(".data");
        div.find(".loading").fadeIn().css("display", "inline-block").html("yükleniyor...");
        $('.form-upload').ajaxForm({
            success: function (data) {
                div.empty();
                $.each(data, function (i) {
                    div.append("<p>" + data[i].NodeName + "</p>");
                    $.each(data[i].SubNodeList, function (k) {
                        div.append("<p> - " + data[i].SubNodeList[k].NodeName + "</p>");
                    });
                });
            }
        }).submit();
        div.find(".loading").fadeOut();
    });
});