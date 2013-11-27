// MODAL
$(document).ready(function () {
    $('._modal').click(function (e) {
        var src = "";

        // link
        if ($(this).attr('href'))
            src = $(this).attr('href');
        // button
        if ($(this).attr("link"))
            src = $(this).attr('link');

        var _width = ($(this).attr('relw') != null) ? $(this).attr('relw') : 600;
        var _height = ($(this).attr('relh') != null) ? $(this).attr('relh') : 360;
        $.modal('<iframe src="' + src + '" width="' + _width + '" height="' + _height + '"></iframe>', {
            overlayClose: true,
            minWidth: parseInt(_width) + 5,
            minHeight: parseInt(_height) + 5
        });
        return false;
    });
});